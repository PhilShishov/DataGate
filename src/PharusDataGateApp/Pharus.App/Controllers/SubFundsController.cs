using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pharus.App.Controllers
{
    public class SubFundsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}