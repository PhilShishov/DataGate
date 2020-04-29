using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataGate.Web.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}