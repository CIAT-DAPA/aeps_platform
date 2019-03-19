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
    public class OptionsController : ManagementController<FrmOptions>
    {
        

        public OptionsController(AEPSContext context, IHostingEnvironment environment) : base(context, environment)
        {
        }

        // GET: Options/Create
        public async override Task<IActionResult> Create()
        {
            await CreateSelectListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Create([Bind("Question,Name,Label,ExtId")] FrmOptions entity)
        {
            if (ModelState.IsValid)
            {
                await _context.GetRepository<FrmOptions>().InsertAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: Options/Edit/5
        public async override Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.GetRepository<FrmOptions>().ByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }
            await CreateSelectListAsync(entity);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Edit(int id, [Bind("Id,Question,Name,Label,ExtId,Enable")] FrmOptions entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.GetRepository<FrmOptions>().UpdateAsync(entity);
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
            await CreateSelectListAsync(entity);
            return View(entity);
        }

        /// <summary>
        /// Method that creates all select list items
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CreateSelectListAsync()
        {
            var question = (RepositoryFrmQuestions)_context.GetRepository<FrmQuestions>();
            ViewData["Question"] = new SelectList((await question.ToListEnableTypesAsync("unique", "multiple")), "Id", "Description");
            return true;
        }

        /// <summary>
        /// Method that creates all select list items
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CreateSelectListAsync(FrmOptions entity)
        {
            var question = (RepositoryFrmQuestions)_context.GetRepository<FrmQuestions>();
            ViewData["Question"] = new SelectList((await question.ToListEnableTypesAsync("unique", "multiple")), "Id", "Description", entity.Question);
            return true;
        }

    }
}
