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
    public class FormsController : Controller
    {
        private readonly FactoryFrmForms _context;

        public FormsController(AEPSContext context)
        {
            _context = new FactoryFrmForms(context);
        }

        // GET: Forms
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToListAsync());
        }

        // GET: Forms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frmForms = await _context.ByIdAsync(id.Value);
            if (frmForms == null)
            {
                return NotFound();
            }

            return View(frmForms);
        }

        // GET: Forms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Title,Description,ExtId")] FrmForms frmForms)
        {
            if (ModelState.IsValid)
            {
                await _context.InsertAsync(frmForms);
                return RedirectToAction(nameof(Index));
            }
            return View(frmForms);
        }

        // GET: Forms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frmForms = await _context.ByIdAsync(id.Value);
            if (frmForms == null)
            {
                return NotFound();
            }
            return View(frmForms);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,Description,Enable,ExtId")] FrmForms frmForms)
        {
            if (id != frmForms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAsync(frmForms);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrmFormsExists(frmForms.Id))
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
            return View(frmForms);
        }

        // GET: Forms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frmForms = await _context.ByIdAsync(id.Value);
            if (frmForms == null)
            {
                return NotFound();
            }

            return View(frmForms);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frmForms = await _context.ByIdAsync(id);
            await _context.DeleteAsync(frmForms);
            return RedirectToAction(nameof(Index));
        }

        private bool FrmFormsExists(int id)
        {
            return _context.ByIdAsync(id) != null ;
        }
    }
}
