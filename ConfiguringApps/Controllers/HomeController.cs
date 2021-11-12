﻿using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Controllers
{

    public class HomeController : Controller
    {
        private UptimeService uptime;
        public HomeController(UptimeService up) 
        {
            uptime = up;
        }
        public IActionResult Index(bool throwException = false)
        {
            if (throwException) 
            {
                throw new System.NullReferenceException();
            }
            return View(new Dictionary<string, string> {
                ["Message"] = "This is the Index Action" ,
                ["Uptime"] = $"{uptime.Uptime}ms"
            });
        }
        public ViewResult Error() => View(nameof(Index), new Dictionary<string, string> { ["Message"] = "This is the Error action" });
    }
}
