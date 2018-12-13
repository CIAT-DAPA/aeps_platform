using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIAT.DAPA.AEPS.Data.Database;
using CIAT.DAPA.AEPS.Data.Factory;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class BlocksController : Controller
    {
        private readonly FactoryFrmBlocks _context;

        public BlocksController(AEPSContext context)
        {
            _context = new FactoryFrmBlocks(context);
        }

        // GET: Blocks
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToListAsync());
        }

        // GET: Blocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frmBlocks = await _context.ByIdAsync(id.Value);
            if (frmBlocks == null)
            {
                return NotFound();
            }

            return View(frmBlocks);
        }

        // GET: Blocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Title,Description,Repeat,Times,ExtId")] FrmBlocks frmBlocks)
        {
            if (ModelState.IsValid)
            {
                await _context.InsertAsync(frmBlocks);
                return RedirectToAction(nameof(Index));
            }
            return View(frmBlocks);
        }

        // GET: Blocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frmBlocks = await _context.ByIdAsync(id.Value);
            if (frmBlocks == null)
            {
                return NotFound();
            }
            return View(frmBlocks);
        }

        // POST: Blocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,Description,Repeat,Times,Enable,ExtId")] FrmBlocks frmBlocks)
        {
            if (id != frmBlocks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAsync(frmBlocks);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrmBlocksExists(frmBlocks.Id))
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
            return View(frmBlocks);
        }

        // GET: Blocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frmBlocks = await _context.ByIdAsync(id.Value);
            if (frmBlocks == null)
            {
                return NotFound();
            }

            return View(frmBlocks);
        }

        // POST: Blocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frmBlocks = await _context.ByIdAsync(id);
            await _context.DeleteAsync(frmBlocks);
            return RedirectToAction(nameof(Index));
        }

        private bool FrmBlocksExists(int id)
        {
            return _context.ByIdAsync(id) != null;
        }
    }
}
