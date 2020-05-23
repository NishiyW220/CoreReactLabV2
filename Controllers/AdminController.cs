using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreReactLab.Models;
using CoreReactLab.DAL;
using CoreReactLab.Controllers;
using Microsoft.EntityFrameworkCore;


namespace CoreReactLab.Controllers
{
    public class AdminController : Controller
    {
     
        /*=====================================================================*/
        private ApplicationContext db;
        public AdminController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Admins.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Admin admin)
        {
            db.Admins.Add(admin);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Admin admin = await db.Admins.FirstOrDefaultAsync(p => p.id == id);
                if (admin != null)
                    return View(admin);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Admin admin= await db.Admins.FirstOrDefaultAsync(p => p.id == id);
                if (admin != null)
                    return View(admin);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Admin admin)
        {
            db.Admins.Update(admin);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
