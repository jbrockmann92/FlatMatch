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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace FlatMatchApp.Controllers
{
    //[ServiceFilter(typeof(GlobalRouting))]
    [Authorize(Roles = "Renter")]
    public class RentersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RentersController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Renters
        public IActionResult Index()
        {
            var viewModel = new RenterViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var renter = _context.Renters.FirstOrDefault(a => a.UserId == userId);
            if (renter is null)
            {
                return RedirectToAction("Create");
            }
            viewModel.Renter = renter;
            var leaseholders = _context.Leaseholders
                                    .Include(l => l.Property)
                                    .Include(l => l.Property.Address)
                                    .ToList();
            //leaseholders = leaseholders.Where( l => l.Property.Address.City == )
            viewModel.Leaseholders = leaseholders;
            //Matcher matcher = new Matcher(_context);
            //matcher.MatchUsers(renter, 53203);
            return View(viewModel);
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
                string uniqueFileName = UploadedFile(renterViewModel);
                //junction table created: UserPreferences
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var renter = renterViewModel.Renter;
                var value = renterViewModel.Value; //Only holds an int, but the code was trying to use it as a collection in the for loop below
                renter.UserId = userId;
                _context.Renters.Add(renter);
                for (int i = 0; i < 9; i++)
                {

                    var newPreferences = new UserPreferences();
                    newPreferences.PreferenceId = i+1;
                    newPreferences.UserId =  userId;  
                    newPreferences.Value = value[i];
                    _context.UserPreferences.Add(newPreferences);

                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", renter.UserId);
            return View(renterViewModel);
        }
        private string UploadedFile(RenterViewModel viewModel)
        {
            string uniqueFileName = null;
            if (viewModel.ProfileUrl != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.ProfileUrl.FileName;
                string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    viewModel.ProfileUrl.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
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

        public IActionResult AboutUs()
        {
            return View();
        }

        private bool RenterExists(int id)
        {
            return _context.Renters.Any(e => e.Id == id);
        }
    }
}
