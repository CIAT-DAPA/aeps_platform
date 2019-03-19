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

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class RulesController : ManagementController<FrmQuestionsRules>
    {

        public RulesController(AEPSContext context, IHostingEnvironment environment) : base(context, environment)
        {
            
        }

        // GET: Rules/Create
        public async override Task<IActionResult> Create()
        {
            CreateSelectListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Create([Bind("Question,App,Type,Message,Rule")] FrmQuestionsRules entity)
        {
            if (ModelState.IsValid)
            {
                await _context.GetRepository<FrmQuestionsRules>().InsertAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: Rules/Edit/5
        public async override Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.GetRepository<FrmQuestionsRules>().ByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }
            CreateSelectListAsync(entity);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Edit(int id, [Bind("Id,Question,App,Type,Message,Rule")] FrmQuestionsRules entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.GetRepository<FrmQuestionsRules>().UpdateAsync(entity);
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
            CreateSelectListAsync(entity);
            return View(entity);
        }

        /// <summary>
        /// Method that creates all select list items
        /// </summary>
        /// <returns></returns>
        private bool CreateSelectListAsync()
        {
            var rules = (RepositoryFrmQuestionsRules)_context.GetRepository<FrmQuestionsRules>();
            ViewData["App"] = new SelectList(rules.ListApps());
            ViewData["Type"] = new SelectList(rules.ListTypes());
            return true;
        }

        /// <summary>
        /// Method that creates all select list items
        /// </summary>
        /// <returns></returns>
        private bool CreateSelectListAsync(FrmQuestionsRules entity)
        {
            var rules = (RepositoryFrmQuestionsRules)_context.GetRepository<FrmQuestionsRules>();
            ViewData["App"] = new SelectList(rules.ListApps(), entity.App);
            ViewData["Type"] = new SelectList(rules.ListTypes(), entity.Type);
            return true;
        }
    }
}
