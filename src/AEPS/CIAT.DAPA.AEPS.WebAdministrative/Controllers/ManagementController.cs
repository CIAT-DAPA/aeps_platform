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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using CIAT.DAPA.AEPS.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using CIAT.DAPA.AEPS.WebAdministrative.Models;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    [Authorize]
    public abstract class ManagementController<T> : Controller
    {
        /// <summary>
        /// Gets the factory to create repositories
        /// </summary>
        protected readonly AEPSFactory _context;

        /// <summary>
        /// Get the enviroment variable
        /// </summary>
        private IHostingEnvironment _hostingEnvironment { get; set; }

        /// <summary>
        /// Get or set the location of folder for importations
        /// </summary>
        protected string ImportFolder { get; set; }

        /// <summary>
        /// Get the management of log
        /// </summary>
        protected ILogger Logger { get; set; }

        /// <summary>
        /// Get or set the user 
        /// </summary>
        protected string CurrentUser { get; set; }

        /// <summary>
        /// Get the controller name
        /// </summary>
        protected string ControllerName { get { return this.ControllerContext.RouteData.Values["controller"].ToString(); } }

        /// <summary>
        /// Get the current action name
        /// </summary>
        protected string ActionName { get { return this.ControllerContext.RouteData.Values["action"].ToString(); } }

        /// <summary>
        /// Construct method
        /// </summary>
        /// <param name="context">Context of the database</param>
        public ManagementController(AEPSContext context, IHostingEnvironment environment, 
                        UserManager<ApplicationUser> userManager, ILogger<T> logger,
                        IHttpContextAccessor httpContextAccessor) : base()
        {
            _context = new AEPSFactory(context);
            _hostingEnvironment = environment;
            ImportFolder = _hostingEnvironment.ContentRootPath + "/Files/Import/";
            Logger = logger;
            CurrentUser =  userManager.GetUserName(httpContextAccessor.HttpContext.User);
        }

        // GET: Controller
        public async virtual Task<IActionResult> Index()
        {
            try
            {
                LogInformation(LogginEvent.List,"List elements");
                return View(await _context.GetRepository<T>().ToListAsync());
            }
            catch (Exception ex)
            {
                LogCritical(LogginEvent.Exception,"System failed", ex);
                return View("Error");
            }
        }

        // GET: Controller/Details/5
        public async virtual Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    LogWarnning(LogginEvent.UserError,"Id don't come");
                    return NotFound();
                }
                LogInformation(LogginEvent.Details, "User is searching id:" + id.Value.ToString());
                var entity = await _context.GetRepository<T>().ByIdAsync(id.Value);
                if (entity == null)
                {
                    LogWarnning(LogginEvent.UserError, "Entity doesn't exist");
                    return NotFound();
                }
                return View(entity);
            }
            catch (Exception ex)
            {
                LogCritical(LogginEvent.Exception, "System failed", ex);
                return View("Error");
            }


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
            try
            {
                if (id == null)
                {
                    LogWarnning(LogginEvent.UserError, "Id don't come");
                    return NotFound();
                }
                LogInformation(LogginEvent.Edit, "User is searching id:" + id.Value.ToString());
                var entity = await _context.GetRepository<T>().ByIdAsync(id.Value);
                if (entity == null)
                {
                    LogWarnning(LogginEvent.UserError, "Entity doesn't exist");
                    return NotFound();
                }
                return View(entity);
            }
            catch (Exception ex)
            {
                LogCritical(LogginEvent.Exception, "System failed", ex);
                return View("Error");
            }
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
            try
            {
                var entity = await _context.GetRepository<T>().ByIdAsync(id);
                await _context.GetRepository<T>().DeleteAsync(entity);
                LogInformation(LogginEvent.Delete,"User deleted the entity with id: " + id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                LogCritical(LogginEvent.Exception,"System failed", ex);
                return View("Error");
            }

        }

        /// <summary>
        /// Method which validates if entity exists in the database
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns>True if it exists, otherwise false</returns>
        protected virtual bool EntityExists(int id) => _context.GetRepository<T>().ByIdAsync(id) != null;
              

        /// <summary>
        /// Register log about information into the system
        /// </summary>
        /// <param name="message">Message for tracing actions</param>
        protected void LogInformation(LogginEvent eventId, string message) => Logger.LogInformation((int)eventId,"{0} {1} {2}", ControllerName + "|" + ActionName, CurrentUser, message);

        /// <summary>
        /// Register log about warning alerts into the system
        /// </summary>
        /// <param name="message">Message for tracing actions</param>
        protected void LogWarnning(LogginEvent eventId,string message) => Logger.LogWarning((int)eventId, "{0} {1} {2}", ControllerName + "|" + ActionName, CurrentUser, message);

        /// <summary>
        /// Register log about exceptions into the system
        /// </summary>
        /// <param name="message">Message for tracing actions</param>
        /// <param name="ex">Exception</param>
        protected void LogCritical(LogginEvent eventId, string message, Exception ex) => Logger.LogCritical((int)eventId, ex, "{0} {1} {2}", ControllerName + "|" + ActionName, CurrentUser, message);
    }
}
