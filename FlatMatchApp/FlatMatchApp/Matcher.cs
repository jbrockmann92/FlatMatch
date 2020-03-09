using FlatMatchApp.Data;
using FlatMatchApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp
{
    //JBrockmann
    public class Matcher
    {
        //Create algorithm here
        private readonly ApplicationDbContext _context;
        public Matcher(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Leaseholder> MatchUsers(Renter renter, string Zip) //This means we'll have to have both a renter and a Zip passed into this method
        {
            var leaseholders = _context.Leaseholders.ToList().Where(l => l.Property.Address.ZipCode == Zip).ToList();
            //Might have to assign the property and address properties based on their ids if they're not stored as they should in db

            List<Leaseholder> finalLeaseholders = new List<Leaseholder>();
            List<Leaseholder> tempLeaseholders = new List<Leaseholder>();
            int leaseholderValue = 0;
            int[,] holder_score = new int[leaseholders.Count, 2];
            //Do I still need this?
            var rPrefs = renter.Preferences;

            //Need to decide if we will have Zip as a property of the renter model or leave off and pass in a different way

            for (int i = 0; i < leaseholders.Count; i++)
            {
                var lPrefs = leaseholders[i].Preferences;

                for (int j = 0; j < 12; j++)
                {
                    var lPrefsValue = _context.UserPreferences.Where(p => p.Id == lPrefs[j].Id).FirstOrDefault().Value;
                    var rPrefsValue = _context.UserPreferences.Where(u => u.UserId == rPrefs[j].Id).FirstOrDefault().Value;

                    leaseholderValue += Math.Abs(lPrefsValue - rPrefsValue);

                    holder_score[j, i] = leaseholderValue;
                    //Not quite right
                }

                tempLeaseholders.Add(leaseholders[i]);
                finalLeaseholders = SortLeaseholders(tempLeaseholders);
            }

        }
    }
}
