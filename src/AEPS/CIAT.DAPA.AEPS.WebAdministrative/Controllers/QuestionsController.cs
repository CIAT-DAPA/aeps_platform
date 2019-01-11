using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIAT.DAPA.AEPS.Data.Database;
using CIAT.DAPA.AEPS.Data.Repositories;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class QuestionsController : ManagementController<FrmQuestions>
    {

        public QuestionsController(AEPSContext context) : base(context)
        {

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Create([Bind("Id,Block,Name,Label,Description,Type,Order,ExtId")] FrmQuestions entity)
        {
            if (ModelState.IsValid)
            {
                await _context.GetRepository<FrmQuestions>().InsertAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Edit(int id, [Bind("Id,Block,Name,Label,Description,Type,Order,Enable,ExtId")] FrmQuestions entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.GetRepository<FrmQuestions>().UpdateAsync(entity);
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

        

        // GET: Questions/Create
        public async override Task<IActionResult> Create()
        {
            await CreateSelectListAsync();
            return View();
        }

        // GET: Questions/Edit/5
        public async override Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.GetRepository<FrmBlocks>().ByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }
            await CreateSelectListAsync();
            return View(entity);
        }

        /// <summary>
        /// Method that creates all select list items
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CreateSelectListAsync()
        {
            var question = (RepositoryFrmQuestions)_context.GetRepository<FrmQuestions>();
            ViewData["Block"] = new SelectList((await _context.GetRepository<FrmBlocks>().ToListEnableAsync()), "Id", "Description");
            ViewData["Type"] = new SelectList( question.ToListType());
            return true;
        }
    }
}
