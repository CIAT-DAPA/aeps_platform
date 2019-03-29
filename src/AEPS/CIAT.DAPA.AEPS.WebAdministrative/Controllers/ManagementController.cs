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
    public abstract class ManagementController<T> : Controller
    {
        /// <summary>
        /// Gets the factory to create repositories
        /// </summary>
        protected readonly AEPSFactory _context;

        private IHostingEnvironment _hostingEnvironment { get; set; }

        protected string ImportFolder { get; set; }

        /// <summary>
        /// Construct method
        /// </summary>
        /// <param name="context">Context of the database</param>
        public ManagementController(AEPSContext context, IHostingEnvironment environment) : base()
        {
            _context = new AEPSFactory(context);
            _hostingEnvironment = environment;
            ImportFolder = _hostingEnvironment.ContentRootPath + "/Files/Import/";
        }

        // GET: Controller
        public async virtual Task<IActionResult> Index()
        {
            return View(await _context.GetRepository<T>().ToListAsync());
        }

        // GET: Controller/Details/5
        public async virtual Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.GetRepository<T>().ByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Controller/Create
        public async virtual Task<IActionResult> Create() => View();



        // POST: Controller/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public abstract Task<IActionResult> Create([Bind("")] T entity);


        // GET: Controller/Edit/5
        public async virtual Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.GetRepository<T>().ByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // POST: Controller/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public abstract Task<IActionResult> Edit(int id, [Bind("")] T entity);

        // POST: Controller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async virtual Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.GetRepository<T>().ByIdAsync(id);
            await _context.GetRepository<T>().DeleteAsync(entity);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Method which validates if entity exists in the database
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns>True if it exists, otherwise false</returns>
        protected virtual bool EntityExists(int id) => _context.GetRepository<T>().ByIdAsync(id) != null;
    }
}
