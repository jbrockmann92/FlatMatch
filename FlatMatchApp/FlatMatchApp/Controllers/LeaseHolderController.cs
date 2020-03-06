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
                return View("Create");
            }
            return View(leaseholder);
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
                editLeaseholder.Property.Address.StreetName = leaseholder.Property.Address.StreetName;
                editLeaseholder.Property.Address.ApartmentNumber = leaseholder.Property.Address.ApartmentNumber;
                editLeaseholder.Property.Address.City = leaseholder.Property.Address.City;
                editLeaseholder.Property.Address.State = leaseholder.Property.Address.State;
                editLeaseholder.Property.Address.ZipCode = leaseholder.Property.Address.ZipCode;
            }

                return RedirectToAction(nameof(Index));
            
        }

        // GET: LeaseHolder/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var leaseholder = _context.Leaseholders.Include(l => l.Property).FirstOrDefault(l => l.Id == id);

            if(leaseholder == null)
            {
                return NotFound();
            }

            return View(leaseholder);
        }

        // POST: LeaseHolder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var leaseholder = _context.Leaseholders.Find(id);
            _context.Leaseholders.Remove(leaseholder);
            _context.SaveChanges();
            return Redirect("Index");
        }
    }
}