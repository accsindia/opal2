using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OPAL.Presentation.Models;

namespace OPAL.Presentation.Controllers
{
    public class SearchController : Controller
    {
        
        public SearchController()
        {
        }

        public IActionResult BasicSearch()
        {
            return View();
        }
    }
}
