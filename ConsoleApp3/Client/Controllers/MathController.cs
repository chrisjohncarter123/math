using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Math;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Client.Controllers
{
    public class MathController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Solve()
        {
            Polynomial poly;

            return View();
        }
    }
}
