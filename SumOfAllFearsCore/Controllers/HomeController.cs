using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SumOfAllFearsCore.Models;

namespace SumOfAllFearsCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(int input1, int input2, int input3, int input4, int input5, int kValue)
        {
            int[] inArray = new int[] { input1, input2, input3, input4, input5 };
            var output = "";
            for(int i = 0; i < inArray.Length; i++)
            {
                for(int s = i + 1; s < inArray.Length; s++ )
                {
                    if(inArray[i] + inArray[s] == kValue)
                    {
                        output += "Success!";
                        break;
                    }
                }
            }

            if(output != "")
            {
                ViewData["Output"] = output;
            }
            else
            {
                ViewData["Output"] = "No solution. Try Again!";
            }
            return View();
        }

        public IActionResult Code()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
