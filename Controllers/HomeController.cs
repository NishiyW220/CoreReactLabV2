using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreReactLab.Models;
using CoreReactLab.DAL;

namespace CoreReactLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return Redirect("../Admin/Index");
        }
        public IActionResult Worker()
        {
            return Redirect("../Workers/Index");
        }

        public IActionResult TypeWorks()
        {
            return Redirect("../TypeWorks/Index");
        }

        public IActionResult Orders()
        {
            return Redirect("../Orders/Index");
        }

        

    }

}