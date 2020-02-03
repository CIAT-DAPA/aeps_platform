using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIAT.DAPA.AEPS.Data.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using CIAT.DAPA.AEPS.Users.Models;
using Microsoft.AspNetCore.Http;
using CIAT.DAPA.AEPS.WebAdministrative.Models;
using CIAT.DAPA.AEPS.Data.Repositories;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class StatesController :  ManagementController<ConStates>
    {

        public StatesController(AEPSContext context, IHostingEnvironment environment,
            UserManager<ApplicationUser> userManager, ILogger<ConStates> logger,
                        IHttpContextAccessor httpContextAccessor) : base(context, environment, userManager, logger, httpContextAccessor)
        {

        }

        // GET: Rules/Create
        public async override Task<IActionResult> Create()
        {
            await CreateSelectListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Create([Bind("Id,Name,Country,ExtId")] ConStates entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity = await _context.GetRepository<ConStates>().InsertAsync(entity);
                    LogInformation(LogginEvent.Create, "Registered a new entity: " + entity.ToString());
                    return RedirectToAction("Details", new { id = entity.Id });
                }
                LogWarnning(LogginEvent.UserError, "Entity is not valid " + entity.ToString());
                return View(entity);
            }
            catch (Exception ex)
            {
                LogCritical(LogginEvent.Exception, "System failed", ex);
                return View("Error");
            }
        }

        // GET: Rules/Edit/5
        public async override Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    LogWarnning(LogginEvent.UserError, "Id don't come");
                    return NotFound();
                }
                LogInformation(LogginEvent.Edit, "User is searching id:" + id.Value.ToString());
                var entity = await _context.GetRepository<ConStates>().ByIdAsync(id.Value);
                if (entity == null)
                {
                    LogWarnning(LogginEvent.UserError, "Entity doesn't exist");
                    return NotFound();
                }
                await CreateSelectListAsync(entity);
                return View(entity);
            }
            catch (Exception ex)
            {
                LogCritical(LogginEvent.Exception, "System failed", ex);
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Edit(int id, [Bind("Id,Name,Country,ExtId")] ConStates entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    LogWarnning(LogginEvent.UserError, "Ids are not the same");
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    if (await _context.GetRepository<ConStates>().UpdateAsync(entity))
                    {
                        LogInformation(LogginEvent.Edit, "Entity updated: " + entity.ToString());
                        return RedirectToAction("Details", new { id = entity.Id });
                    }
                    else
                    {
                        LogWarnning(LogginEvent.Edit, "Entity wasn't updated " + entity.ToString());
                        return NotFound();
                    }
                }
                LogWarnning(LogginEvent.UserError, "Entity is not validated " + entity.ToString());
                return View(entity);
            }
            catch (Exception ex)
            {
                LogCritical(LogginEvent.Exception, "System failed", ex);
                return View("Error");
            }
        }

        /// <summary>
        /// Method that creates all select list items
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CreateSelectListAsync()
        {
            var countries = (RepositoryConCountries)_context.GetRepository<ConCountries>();
            ViewData["Country"] = new SelectList((await countries.ToListEnableAsync()), "Id", "Name");
            return true;
        }

        /// <summary>
        /// Method that creates all select list items
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CreateSelectListAsync(ConStates entity)
        {
            var countries = (RepositoryConCountries)_context.GetRepository<ConCountries>();
            ViewData["Country"] = new SelectList((await countries.ToListEnableAsync()), "Id", "Name", entity.Country);
            return true;
        }
    }
}
