using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlatMatchApp.Data;
using FlatMatchApp.Models;
using Microsoft.AspNetCore.Authorization;
using FlatMatchApp.ActionFilters;
using System.Security.Claims;

namespace FlatMatchApp.Controllers
{
    //[ServiceFilter(typeof(GlobalRouting))]
    [Authorize(Roles = "Renter")]
    public class RentersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Renters
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var renter = _context.Renters.FirstOrDefault(a => a.UserId == userId);
            if (renter is null)
            {
                return RedirectToAction("Create");
            }
            
            return RedirectToAction("Edit");
        }

        // GET: Renters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renter = await _context.Renters
                .Include(r => r.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renter == null)
            {
                return NotFound();
            }

            return View(renter);
        }

        // GET: Renters/Create
        public IActionResult Create()
        {
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id"); A.Sanchez: Following format of trashcollector project, we can connect as needed
            return View();
        }

        // POST: Renters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,UserId")] Renter renter) 
        //Above is original code.  A.Sanchez: Using simpler method from trashcollector, let me know if you have questions
        public IActionResult Create(RenterViewModel renterViewModel)
        {
            if (ModelState.IsValid)
            {
                //Right now the var value that's assigned is only an int, not a list of ints. Probably something we'll
                //have to go over on Monday. The junction table is something that none of us have done before,
                //so it will take some getting used to
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var renter = renterViewModel.Renter;
                var value = renterViewModel.Value; //Only holds an int, but the code was trying to use it as a collection in the for loop below
                renter.UserId = userId;
                _context.Renters.Add(renter);
                var preferences = renterViewModel.Preferences;
                for (int i = 0; i < preferences.Count; i++)
                {

                    //Not quite right here. Need to have a list of preferences from the html or something before we can run this.
                    //It looks right as far as using the junction table goes, but we don't have any preferences yet

                    var newPreferences = new UserPreferences();
                    newPreferences.PreferenceId = preferences[i].Id;
                    newPreferences.UserId =  int.Parse(userId);  //we should have this be a string instead, otherwise we will have to use the intparse or converttoint every time
                    newPreferences.Value = value;
                    _context.UserPreferences.Add(newPreferences);
                    //added list of ints to renter view controller in order to 
                    //be able to capture value to be stored in preferences
                    //This method takes up a lot of space/memory, I suggest we simply add preferences to the renter model
                    //or create a second table that hangs onto all prerences at once along with each individual value instead.
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

                

                
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", renter.UserId);
            return View(renterViewModel);
        }

        // GET: Renters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renter = await _context.Renters.FindAsync(id);
            if (renter == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", renter.UserId);
            return View(renter);
        }

        // POST: Renters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,UserId")] Renter renter)
        {
            if (id != renter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenterExists(renter.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", renter.UserId);
            return View(renter);
        }

        // GET: Renters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renter = await _context.Renters
                .Include(r => r.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renter == null)
            {
                return NotFound();
            }

            return View(renter);
        }

        // POST: Renters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renter = await _context.Renters.FindAsync(id);
            _context.Renters.Remove(renter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenterExists(int id)
        {
            return _context.Renters.Any(e => e.Id == id);
        }
    }
}
