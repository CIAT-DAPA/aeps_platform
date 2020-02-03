using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIAT.DAPA.AEPS.Users.Models;
using CIAT.DAPA.AEPS.WebAdministrative.Models;
using CIAT.DAPA.AEPS.WebAdministrative.Models.InstallViewModels;
using CIAT.DAPA.AEPS.WebAdministrative.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class InstallController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        /// <summary>
        /// Get the enviroment variable
        /// </summary>
        private IHostingEnvironment _hostingEnvironment { get; set; }

        /// <summary>
        /// Get the management of log
        /// </summary>
        protected ILogger Logger { get; set; }
        /// <summary>
        /// Get if the application was installed or not
        /// </summary>
        private bool Installed { get; set; }

        /// <summary>
        /// Construct method
        /// </summary>
        /// <param name="context">Context of the database</param>
        public InstallController(IOptions<Settings> settings, IHostingEnvironment environment,
                        UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                            IEmailSender emailSender, ILogger<ApplicationUser> logger,
                        IHttpContextAccessor httpContextAccessor) : base()
        {
            _hostingEnvironment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            Logger = logger;
            Installed = settings.Value.Installed;
        }

        // GET: /Install/Index
        [HttpGet]
        public IActionResult Index()
        {
            if (Installed)
                return RedirectToAction("Index", "Home");
            return View();
        }

        // POST: /Install/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(InstallViewModel model)
        {
            if (Installed)
                return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //_logger.LogInformation("User created a new account with password.");
                    return RedirectToAction("InstallFinished");
                }
            }

            return View(model);
        }

        // GET: /Install/Installed
        [HttpGet]
        public IActionResult InstallFinished()
        {
            if (Installed)
                return RedirectToAction("Index", "Home");
            return View();
        }
    }
}