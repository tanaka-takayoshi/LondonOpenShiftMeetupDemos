using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentConfigurationWithSecretExample.Models;
using Microsoft.Extensions.Options;

namespace EnvironmentConfigurationWithSecretExample.Controllers
{
    public class HomeController : Controller
    {
        private MyOption myOption;

        public HomeController(IOptions<MyOption> myOption)
        {
            this.myOption = myOption.Value;
        }

        public IActionResult Index()
        {
            ViewData["SecertKey"] = myOption.SecretKey;
            ViewData["SecertValue"] = myOption.SecretValue;
            ViewData["EnvironmentName"] = myOption.EnvironmentName;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
