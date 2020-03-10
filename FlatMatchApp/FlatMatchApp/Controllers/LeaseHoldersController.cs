using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FlatMatchApp.ActionFilters;
using FlatMatchApp.Data;
using FlatMatchApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatMatchApp.Controllers
{
    //[ServiceFilter(typeof(GlobalRouting))]
    [Authorize(Roles = "Leaseholder")]
    public class LeaseholdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LeaseholdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaseHolder
        public IActionResult Index() //RP
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var leaseholder = _context.Leaseholders.Include(l => l.Property.Address).Where(l => l.UserId == userId).ToList();

            if (leaseholder == null)
            {
                return RedirectToAction("Create");
            }
            return View(leaseholder);
        }

        // GET: LeaseHolder/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewModel = new LeaseholderViewModel();
            var leaseholder = _context.Leaseholders.Include(l => l.Property.Address).FirstOrDefault(l => l.Id == id);
            //var rPrefs = _context.UserPreferences.Where(u => u.UserId == leaseholder.UserId).ToList();
            viewModel.Leaseholder = leaseholder;
            
            return View(viewModel);
        }
        // GET: LeaseHolder/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaseHolder/Create
        [HttpPost]
        public IActionResult Create(LeaseholderViewModel leaseholderViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var leaseholder = leaseholderViewModel.Leaseholder;
            var value = leaseholderViewModel.Value;
            leaseholder.UserId = userId;
            _context.Leaseholders.Add(leaseholderViewModel.Leaseholder);
            for (int i = 0; i < 9; i++)
            {

                var newPreferences = new UserPreferences();
                newPreferences.PreferenceId = i + 1;
                newPreferences.UserId = userId;
                newPreferences.Value = value[i];
                _context.UserPreferences.Add(newPreferences);

            }
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
            if (id == null)
            {
                return NotFound();
            }

            var leaseholder = _context.Leaseholders.Include(l => l.Preferences).Include(l => l.Property).FirstOrDefault(l => l.Id == id);

            if (leaseholder == null)
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


        //Can create new method called AssignList() or something that takes in a List<Preference>, foreach's over the list and assigns them to the currently logged
        //in user using that code David gave to us
    }
}