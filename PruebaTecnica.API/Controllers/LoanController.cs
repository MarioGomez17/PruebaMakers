﻿using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.API.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
