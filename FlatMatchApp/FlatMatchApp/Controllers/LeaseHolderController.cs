using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FlatMatchApp.Data;
using FlatMatchApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlatMatchApp.Controllers
{
    public class LeaseholderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaseholderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaseHolder
        public IActionResult Index() //RP
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var leaseholder = _context.Leaseholders.FirstOrDefault(l => l.UserId == userId);
            if(leaseholder == null)
            {
                return NotFound();
            }
            return View(leaseholder);
        }

        // GET: LeaseHolder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaseHolder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaseHolder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaseHolder/Edit/5
        public ActionResult Edit(int? id) //RP
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var leaseholder = _context.Leaseholders.FirstOrDefault(l => l.UserId == userId);
            return View(leaseholder);
        }

        // POST: LeaseHolder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("FirstName,LastName")] Leaseholder leaseholder) //RP
        {
            if (id != leaseholder.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                Leaseholder editLeaseholder = _context.Leaseholders.Find(id);
                editLeaseholder.FirstName = leaseholder.FirstName;
                editLeaseholder.LastName = leaseholder.LastName;
                editLeaseholder.Address.StreetName = leaseholder.Address.StreetName;
                editLeaseholder.Address.ApartmentNumber = leaseholder.Address.ApartmentNumber;
                editLeaseholder.Address.City = leaseholder.Address.City;
                editLeaseholder.Address.State = leaseholder.Address.State;
                editLeaseholder.Address.ZipCode = leaseholder.Address.ZipCode;
            }

                return RedirectToAction(nameof(Index));
            
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