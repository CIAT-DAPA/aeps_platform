﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIAT.DAPA.AEPS.Data.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using CIAT.DAPA.AEPS.Users.Models;
using Microsoft.AspNetCore.Http;
using CIAT.DAPA.AEPS.WebAdministrative.Models;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class BlocksController : ManagementController<FrmBlocks>
    {
        public BlocksController(AEPSContext context, IHostingEnvironment environment, 
            UserManager<ApplicationUser> userManager, ILogger<FrmBlocks> logger,
                        IHttpContextAccessor httpContextAccessor) : base(context, environment, userManager, logger, httpContextAccessor)
        {
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Create([Bind("Id,Name,Title,Description,Repeat,Times,ExtId")] FrmBlocks entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity = await _context.GetRepository<FrmBlocks>().InsertAsync(entity);
                    LogInformation(LogginEvent.Create,"Registered a new entity: " + entity.ToString());
                    return RedirectToAction("Details",new { id = entity.Id });
                }
                LogWarnning(LogginEvent.UserError,"Entity is not valid " + entity.ToString());
                return View(entity);
            }
            catch (Exception ex)
            {
                LogCritical(LogginEvent.Exception,"System failed", ex);
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async override Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,Description,Repeat,Times,Enable,ExtId")] FrmBlocks entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    LogWarnning(LogginEvent.UserError,"Ids are not the same");
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    if(await _context.GetRepository<FrmBlocks>().UpdateAsync(entity))
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
    }
}
