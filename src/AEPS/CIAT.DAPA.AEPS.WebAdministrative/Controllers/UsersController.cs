using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIAT.DAPA.AEPS.Users.Models;
using CIAT.DAPA.AEPS.WebAdministrative.Models;
using CIAT.DAPA.AEPS.WebAdministrative.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

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

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                            IEmailSender emailSender, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        /// <summary>
        /// Register log about information into the system
        /// </summary>
        /// <param name="message">Message for tracing actions</param>
        protected void LogInformation(LogginEvent eventId, string message) => _logger.LogInformation((int)eventId, "{0} {1} {2}", ControllerName + "|" + ActionName, CurrentUser, message);

        /// <summary>
        /// Register log about warning alerts into the system
        /// </summary>
        /// <param name="message">Message for tracing actions</param>
        protected void LogWarnning(LogginEvent eventId, string message) => _logger.LogWarning((int)eventId, "{0} {1} {2}", ControllerName + "|" + ActionName, CurrentUser, message);

        /// <summary>
        /// Register log about exceptions into the system
        /// </summary>
        /// <param name="message">Message for tracing actions</param>
        /// <param name="ex">Exception</param>
        protected void LogCritical(LogginEvent eventId, string message, Exception ex) => _logger.LogCritical((int)eventId, ex, "{0} {1} {2}", ControllerName + "|" + ActionName, CurrentUser, message);

        // GET: Controller
        public async virtual Task<IActionResult> Index()
        {
            try
            {
                LogInformation(LogginEvent.List, "List elements");
                return View(_userManager.Users.ToList());
            }
            catch (Exception ex)
            {
                LogCritical(LogginEvent.Exception, "System failed", ex);
                return View("Error");
            }
        }


    }
}