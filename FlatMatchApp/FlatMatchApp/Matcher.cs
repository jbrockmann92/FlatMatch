using FlatMatchApp.Data;
using FlatMatchApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;
        public Matcher(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Leaseholder> MatchUsers(Renter renter, int Zip) //This means we'll have to have both a renter and a Zip passed into this method
        {
            var leaseholders = _context.Leaseholders.Include(l => l.Property).Include(l => l.Property.Address).ToList().Where(l => l.Property.Address.ZipCode == Zip.ToString()).ToList();
            List<Leaseholder> finalLeaseholders = new List<Leaseholder>();
            List<int[,]> tempLeaseholders = new List<int[,]>();
            int leaseholderValue = 0;
            int[,] holder_score = new int[leaseholders.Count, 2];
            var rPrefs = _context.UserPreferences.Where(u => u.UserId == renter.UserId).ToList();
            //I think that's right

            for (int i = 0; i < leaseholders.Count; i++)
            {
                var lPrefs = _context.UserPreferences.Where(u => u.UserId == leaseholders[i].UserId).ToList();

                for (int j = 0; j < 12; j++)
                {
                    var lPrefsValue = lPrefs[j].Value;
                    var rPrefsValue = rPrefs[j].Value;

                    leaseholderValue += Math.Abs(lPrefsValue - rPrefsValue);
                }
                holder_score[i, 0] = leaseholderValue;
                holder_score[i, 1] = leaseholders[i].Id;
                tempLeaseholders.Add(holder_score);
            }

            finalLeaseholders = SortLeaseholders(tempLeaseholders);
            return finalLeaseholders;
            //Might want to return a list or IQueryable of leaseholders. Or RedirectToAction("Index", IQueryable<Leaseholder>)
            //or something similar
        }

        public List<Leaseholder> SortLeaseholders(List<int[,]> leaseholdersArrayList)
        {
            List<Leaseholder> leaseholders = new List<Leaseholder>();
            var leaseholdersArrays = leaseholdersArrayList.OrderBy(l => l[0,0]).ToList();
            //Will only take the first one right now. Might have to do a for loop to actually sort this based on the [0] of each array in the array

            for (int i = 0; i < leaseholdersArrays.Count; i++)
            {
                //Should be able to use this for loop to sort if necessary
                var tempList = leaseholdersArrays[i];
                leaseholders.Add(_context.Leaseholders.Where(l => l.Id == tempList[i,1]).FirstOrDefault());
            }
        return leaseholders;
        }
    }
}
