using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIAT.DAPA.AEPS.Data.Database;
using CIAT.DAPA.AEPS.Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using CIAT.DAPA.AEPS.ODK;
using Microsoft.AspNetCore.Http;
using CIAT.DAPA.AEPS.ODK.Models;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class FormsController : ManagementController<FrmForms>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context"></param>
        public FormsController(AEPSContext context, IHostingEnvironment environment) : base(context, environment)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Create([Bind("Id,Name,Title,Description,Repeat,Times,ExtId")] FrmForms entity)
        {
            if (ModelState.IsValid)
            {
                await _context.GetRepository<FrmForms>().InsertAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,Description,Repeat,Times,Enable,ExtId")] FrmForms entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.GetRepository<FrmForms>().UpdateAsync(entity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityExists(entity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: Forms/Configure/5
        public async Task<IActionResult> SetBlocks(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get repositories
            var rbf = (RepositoryFrmBlocksForms)_context.GetRepository<FrmBlocksForms>();
            var rb = (RepositoryFrmBlocks)_context.GetRepository<FrmBlocks>();
            var f = (RepositoryFrmForms)_context.GetRepository<FrmForms>();
            // List blocks by form
            var blocksInForm = await rbf.ToListByFormAsync(id.Value);
            // Get all blocks
            var blocks = await rb.ToListEnableAsync();
            // Filter blocks, which are not parted of the form
            var ids = blocksInForm.Select(p => p.Block).Distinct();
            ViewData["Block"] = new SelectList(blocks.Where(p => !ids.Contains(p.Id)), "Id", "Description");
            ViewData["Form"] = await f.ByIdAsync(id.Value);
            return View(blocksInForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBlock([Bind("Form,Block,Order")] FrmBlocksForms entity)
        {
            if (ModelState.IsValid)
            {
                await _context.GetRepository<FrmBlocksForms>().InsertAsync(entity);
                return RedirectToAction(nameof(SetBlocks), new { id = entity.Block });
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveBlock([Bind("Form,Block")] FrmBlocksForms entity)
        {
            if (ModelState.IsValid)
            {
                await _context.GetRepository<FrmBlocksForms>().DeleteAsync(entity);
                return RedirectToAction(nameof(SetBlocks), new { id = entity.Block });
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportXLSForm(IFormFile file)
        {
            
            if (file == null)
                return NotFound();

            //Declaring variables
            ImportXLSForm import;
            Stream stream;
            XLSForm xlsform;


            RepositoryFrmBlocksForms rBlocksForms = (RepositoryFrmBlocksForms)_context.GetRepository<FrmBlocksForms>();
            RepositoryFrmBlocks rBlocks = (RepositoryFrmBlocks)_context.GetRepository<FrmBlocks>();
            RepositoryFrmForms rForms = (RepositoryFrmForms)_context.GetRepository<FrmForms>();
            RepositoryFrmQuestions rQuestions = (RepositoryFrmQuestions)_context.GetRepository<FrmQuestions>();
            RepositoryFrmQuestionsRules rQuestionsRules = (RepositoryFrmQuestionsRules)_context.GetRepository<FrmQuestionsRules>();
            RepositoryFrmOptions rOptions = (RepositoryFrmOptions)_context.GetRepository<FrmOptions>();

            FrmBlocks block = null;
            FrmQuestions question = null;
            List<FrmQuestionsRules> questionRules = null;
            List<FrmOptions> options = null;
            string[] types;
            int order = 1;

            // Create a file
            var f = file;
            string fileName = string.Empty;
            do
            {
                fileName = ImportFolder + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + f.FileName;
            } while (System.IO.File.Exists(fileName));
            using (stream = new FileStream(fileName, FileMode.Create))
            {
                await f.CopyToAsync(stream);
                stream.Close();
            }

            // Importing data
            import = new ImportXLSForm();
            xlsform = await import.LoadAsync(fileName, "plot");
                       
            // Saving form
            foreach (var s in xlsform.Surveys)
            {
                // Start a group, it could be a group or repeat
                if (s.Type.Equals("begin group") || s.Type.Equals("begin repeat"))
                {
                    block = new FrmBlocks()
                    {
                        Name = s.Name,
                        Title = s.Label,
                        Description = s.Label,
                        Repeat = (byte)(s.Type.Equals("begin repeat") ? 1 : 0),

                    };
                    block = await rBlocks.InsertAsync(block);
                }
                // End the group
                else if (s.Type.StartsWith("end"))
                {
                    block = null;
                }
                // Questions
                else
                {
                    types = s.Type.Split(" ");

                    question = new FrmQuestions()
                    {
                        Block = block.Id,
                        Name = s.Name,
                        Label = s.Label,
                        Description = s.Hint,
                        Type = GetTypeODK(types[0]),
                        Order = order
                    };

                    question = await rQuestions.InsertAsync(question);

                    // Question Rules
                    questionRules = new List<FrmQuestionsRules>();
                    if (s.Required.Equals("yes"))
                        questionRules.Add(new FrmQuestionsRules()
                        {
                            App = "odk",
                            Message = s.RequiredMessage,
                            Question = question.Id,
                            Type = "required",
                            Rule = "yes"
                        });
                    if (!string.IsNullOrEmpty(s.Constraint))
                    {
                        questionRules.Add(new FrmQuestionsRules()
                        {
                            App = "odk",
                            Message = s.ConstraintMessage,
                            Question = question.Id,
                            Type = "constraint",
                            Rule = s.Constraint
                        });
                    }
                    if (!string.IsNullOrEmpty(s.Relevant))
                    {
                        questionRules.Add(new FrmQuestionsRules()
                        {
                            App = "odk",
                            Message = string.Empty,
                            Question = question.Id,
                            Type = "relevant",
                            Rule = s.Relevant
                        });
                    }
                    if (!string.IsNullOrEmpty(s.Calculation))
                    {
                        questionRules.Add(new FrmQuestionsRules()
                        {
                            App = "odk",
                            Message = string.Empty,
                            Question = question.Id,
                            Type = "calculation",
                            Rule = s.Calculation
                        });
                    }
                    if (!string.IsNullOrEmpty(s.ChoiceFilter))
                    {
                        questionRules.Add(new FrmQuestionsRules()
                        {
                            App = "odk",
                            Message = string.Empty,
                            Question = question.Id,
                            Type = "choice_filter",
                            Rule = s.ChoiceFilter
                        });
                    }
                    if (!string.IsNullOrEmpty(s.Appearance))
                    {
                        questionRules.Add(new FrmQuestionsRules()
                        {
                            App = "odk",
                            Message = string.Empty,
                            Question = question.Id,
                            Type = "appearance",
                            Rule = s.Appearance
                        });
                    }

                    foreach (var qr in questionRules)
                        await rQuestionsRules.InsertAsync(qr);

                    // Selection questions
                    if (types.Length > 1)
                    {
                        if (question.Type.Equals("unique") || question.Type.Equals("multiple"))
                        {
                            options = new List<FrmOptions>();
                            foreach (var o in xlsform.Choices.Where(p => p.ListName.Equals(types[0])))
                            {
                                await rOptions.InsertAsync(new FrmOptions()
                                {
                                    Question = question.Id,
                                    Name = o.Name,
                                    Label = o.Label
                                });
                            }
                        }
                    }
                }
                order += 1;
            }

            return View("Index");
        }

        private string GetTypeODK(string type)
        {
            string r = string.Empty;
            if (type.Equals("text"))
                r = "string";
            else if (type.Equals("integer"))
                r = "int";
            else if (type.Equals("decimal"))
                r = "double";
            else if (type.Equals("select_one"))
                r = "unique";
            else if (type.Equals("select_multiple"))
                r = "multiple";
            else if (type.Equals("date"))
                r = "date";
            else if (type.Equals("time"))
                r = "time";
            else if (type.Equals("dateTime"))
                r = "datetime";
            else if (type.Equals(""))
                r = "bool";
            return r;
        }
    }
}
