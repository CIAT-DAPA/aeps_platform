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
    public class FormsController : ManagementController<FrmForms>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context"></param>
        public FormsController(AEPSContext context): base(context)
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
                return RedirectToAction(nameof(SetBlocks),new { id = entity.Block});
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
        public async Task<IActionResult> ImportXLSForm()
        {
            // Get file
            var form = HttpContext.Request.Form;

            if (form.Files.Count <= 0)
                return NotFound();

            var f = form.Files[0];
            
            
            return View();
        }
    }
}
