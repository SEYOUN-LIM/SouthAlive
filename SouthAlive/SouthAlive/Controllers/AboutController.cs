﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SouthAlive.Controllers
{
    public class AboutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Introduction()
        {
            return View();
        }

        public IActionResult Organisation()
        {
            return View();
        }

        public IActionResult Teams_And_Projects()
        {
            return View();
        }

        public IActionResult Results()
        {
            return View();
        }

        public IActionResult SponsorInformation()
        {
            return View();
        }
        public IActionResult LocalInformation()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
