﻿using FlatMatchApp.Data;
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

            List<Leaseholder> finalLeaseholders = new List<Leaseholder>();
            List<int[,]> tempLeaseholders = new List<int[,]>();
            int leaseholderValue = 0;
            int[,] holder_score = new int[leaseholders.Count, 2];
            var rPrefs = renter.Preferences;

            for (int i = 0; i < leaseholders.Count; i++)
            {
                var lPrefs = leaseholders[i].Preferences;

                for (int j = 0; j < 12; j++)
                {
                    var lPrefsValue = _context.UserPreferences.Where(p => p.Id == lPrefs[j].Id).FirstOrDefault().Value;
                    var rPrefsValue = _context.UserPreferences.Where(u => u.UserId == rPrefs[j].Id.ToString()).FirstOrDefault().Value;

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

            //Now sort in descending order according to the highest value, then grab the leaseholders that match those ids and put them into the list in order
            //Probably a more efficient way to do this?
            List<Leaseholder> leaseholders = new List<Leaseholder>();

            var leaseholdersArrays = leaseholdersArrayList.OrderBy(l => l).ToList();

            for (int i = 0; i < leaseholdersArrays.Count; i++)
            {
                var tempList = leaseholdersArrays[i];
                leaseholders.Add(_context.Leaseholders.Where(l => l.Id == tempList[i,1]).FirstOrDefault());
            }



            //return finalLeaseholders;
            //Might want to return a list or IQueryable of leaseholders. Or RedirectToAction("Index", IQueryable<Leaseholder>)
            //or something similar
        }

        public List<Leaseholder> SortLeaseholders(List<Leaseholder> leaseholders)
        {
            return leaseholders;
            //place holder return ^ so it temp is not an error
            //Sort them in descending order so they can be returned and printed to the screen

        }
    }
}
