using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DTR.Controllers
{
    public class TeamController : Controller
    {

        [HttpGet("Review")]
        public IActionResult Index()
        {
            return View();
        }
    }
}