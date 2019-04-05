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
using Microsoft.AspNetCore.Identity;
using CIAT.DAPA.AEPS.Users.Models;
using Microsoft.AspNetCore.Http;
using CIAT.DAPA.AEPS.WebAdministrative.Models;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class QuestionsController : ManagementController<FrmQuestions>
    {

        public QuestionsController(AEPSContext context, IHostingEnvironment environment,
            UserManager<ApplicationUser> userManager, ILogger<FrmQuestions> logger,
                        IHttpContextAccessor httpContextAccessor) : base(context, environment, userManager, logger, httpContextAccessor)
        {

        }

        // GET: Questions/Create
        public async override Task<IActionResult> Create()
        {
            await CreateSelectListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Create([Bind("Id,Block,Name,Label,Description,Type,Order,ExtId")] FrmQuestions entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity = await _context.GetRepository<FrmQuestions>().InsertAsync(entity);
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

        // GET: Questions/Edit/5
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
                var entity = await _context.GetRepository<FrmQuestions>().ByIdAsync(id.Value);
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
        public async override Task<IActionResult> Edit(int id, [Bind("Id,Block,Name,Label,Description,Type,Order,Enable,ExtId")] FrmQuestions entity)
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
                    if (await _context.GetRepository<FrmQuestions>().UpdateAsync(entity))
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
                await CreateSelectListAsync(entity);
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
            var question = (RepositoryFrmQuestions)_context.GetRepository<FrmQuestions>();
            ViewData["Block"] = new SelectList((await _context.GetRepository<FrmBlocks>().ToListEnableAsync()), "Id", "Description");
            ViewData["Type"] = new SelectList( question.ToListType());
            return true;
        }

        /// <summary>
        /// Method that creates all select list items
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CreateSelectListAsync(FrmQuestions entity)
        {
            var question = (RepositoryFrmQuestions)_context.GetRepository<FrmQuestions>();
            ViewData["Block"] = new SelectList((await _context.GetRepository<FrmBlocks>().ToListEnableAsync()), "Id", "Description",entity.Block);
            ViewData["Type"] = new SelectList(question.ToListType(), entity.Type);
            return true;
        }
    }
}
