using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using RandomPlanetGenerator.Models;
using Microsoft.Framework.Runtime;
using System.IO;
using Microsoft.AspNet.Hosting;

namespace RandomPlanetGenerator.Controllers {
    public class HomeController : Controller {
        private readonly IApplicationEnvironment _env;

        public HomeController(IApplicationEnvironment env) {
            _env = env;
        }

        public IActionResult Index() {
            var p = new Planet().Generate();
            var imagetemp = Directory.GetFiles(_env.ApplicationBasePath + "/wwwroot/images/planets/")[new Random().Next(Directory.GetFiles(_env.ApplicationBasePath + "/wwwroot/images/planets").Length)];
            p.Image = imagetemp.Substring(imagetemp.LastIndexOf("/"));
            ViewBag.planet = p;
            ViewBag.planetstring = p.ToString();

            return View();
        }
    }
}
