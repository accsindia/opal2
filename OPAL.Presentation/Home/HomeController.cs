﻿using Microsoft.AspNetCore.Mvc;

namespace OPAL.Presentation.Home
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}