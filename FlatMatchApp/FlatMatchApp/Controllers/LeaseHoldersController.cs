using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
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
using static System.Net.Mime.MediaTypeNames;

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
        public IActionResult Index()
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rPrefs = _context.UserPreferences.Include(l => l.PreferenceName).Where(u => u.UserId == userId).ToList();
            viewModel.Leaseholder = leaseholder;

            //Jbrockmann
            System.Drawing.Image image = System.Drawing.Image.FromFile(@"robin.jpg");
            viewModel.Value = new List<int>();
            viewModel.Value.Add(CheckImageBrightness(image)); //Add this to the values list, then just grab length - 1 for the if statement in the <script>            
            
            viewModel.UserPreferences = rPrefs;
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var leaseholder = _context.Leaseholders.Include(l => l.Property).FirstOrDefault(l => l.Id == id);
            var viewModel = new LeaseholderViewModel();
            viewModel.Leaseholder = leaseholder;

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(LeaseholderViewModel leaseholderViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            leaseholderViewModel.Leaseholder.UserId = userId;
            var leaseholderDb = _context.Leaseholders.Include(l => l.Property).Single(l => l.UserId == userId);
            leaseholderDb.FirstName = leaseholderViewModel.Leaseholder.FirstName;
            leaseholderDb.LastName = leaseholderViewModel.Leaseholder.LastName;
            leaseholderDb.ProfileUrl = leaseholderViewModel.Leaseholder.ProfileUrl;
            leaseholderDb.Property.isAvailable = leaseholderViewModel.Leaseholder.Property.isAvailable;
            leaseholderDb.Property.SquareFootage = leaseholderViewModel.Leaseholder.Property.SquareFootage;
            leaseholderDb.Property.Price = leaseholderViewModel.Leaseholder.Property.Price;
            leaseholderDb.Property.NumberBedrooms = leaseholderViewModel.Leaseholder.Property.NumberBedrooms;

            _context.SaveChanges();
            return RedirectToAction("Index");
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

        public int CheckImageBrightness(System.Drawing.Image image)
        {
            var smallImage = new Bitmap(image, new Size(1, 1));
            //Need to multiply by 100 before returning so it's right when I measure it
            var color = smallImage.GetPixel(0, 0);
            float brightness = color.GetBrightness();
            int brightnessInt = Convert.ToInt32(100 * brightness);
            return brightnessInt;
        }
    }
}