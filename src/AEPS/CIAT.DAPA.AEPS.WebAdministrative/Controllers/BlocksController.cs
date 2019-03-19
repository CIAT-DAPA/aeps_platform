using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIAT.DAPA.AEPS.Data.Database;
using Microsoft.AspNetCore.Hosting;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class BlocksController : ManagementController<FrmBlocks>
    {
        public BlocksController(AEPSContext context, IHostingEnvironment environment) : base(context, environment)
        {
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Create([Bind("Id,Name,Title,Description,Repeat,Times,ExtId")] FrmBlocks entity)
        {
            if (ModelState.IsValid)
            {
                await _context.GetRepository<FrmBlocks>().InsertAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,Description,Repeat,Times,Enable,ExtId")] FrmBlocks entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.GetRepository<FrmBlocks>().UpdateAsync(entity);
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
    }
}
