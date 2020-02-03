using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CIAT.DAPA.AEPS.WebAdministrative.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index(string id)
        {
            string url = "http://localhost:8088/r/1?standalone=true";
            if (string.IsNullOrEmpty(id))
                RedirectToAction("Index", "Home");
            else if (id == "2")
                url = "http://localhost:8088/r/2?standalone=true";
            return Redirect(url);
        }
    }
}