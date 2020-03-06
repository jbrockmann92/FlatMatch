using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FlatMatchApp.Data;
using FlatMatchApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatMatchApp.Controllers
{
    public class LeaseholderController : Controller
    {
        private ApplicationDbContext _context;
        public LeaseholderController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: LeaseHolder

        public ActionResult Index()
        {
            return View();
        }

        // GET: LeaseHolder/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var leaseholder = _context.Leaseholders.SingleOrDefault(x => x.Id == id);
            return View(leaseholder);
        }

        // GET: LeaseHolder/Create
        [HttpGet]
        public IActionResult Create()
        {

            var leaseholder = new Leaseholder();
            return View(leaseholder);



        }

        // POST: LeaseHolder/Create
        [HttpPost]
        public IActionResult Create(Leaseholder leaseholder)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            leaseholder.UserId = userId;
            _context.Leaseholders.Add(leaseholder);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LeaseHolder/Edit/5
        public ActionResult Edit(int id)
        {
            
        }

        // POST: LeaseHolder/Edit/5
        [HttpPost]
        public IActionResult Edit(Leaseholder leaseholder)
        {
           
        }

        // GET: LeaseHolder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaseHolder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}