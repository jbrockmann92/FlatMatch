using FlatMatchApp.Data;
using FlatMatchApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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


        public List<Leaseholder> MatchUsers(Renter renter)
        {
            var leaseholders = _context.Leaseholders.ToList();
            List<Leaseholder> finalLeaseholders = new List<Leaseholder>();
            int leaseholderValue;


            //Will be a series of values, 1-5, that I will use to match the same values together
            //How to make sure that the list doesn't just choose however may they have in their list of prefs
            //and match [0] to [0], etc., and end up matching two different types of pref?

            

            //The closer their numbers are, the closer they are to a match.
            //Divide their score by their total number of preferences, the closer they are to 1, the higher
            //that leaseholder shows up on the list?

            //Some kind of sort algorithm to put the highest leaseholders at the beginning of the list. But only return according to certain criteria

            //Need returned from the search an array of the full length of the number of search terms, with
            //a 0 or something in each place they didn't check the box?

            //No I don't. Just need to check each one's id in the junction table and see if it's there. Then I can do all that stuff in here

            //Add weight to the preference table? They can choose from a list of 1-5 how important the given preference is to them

            //Probably want to use some ternaries in the algorithm

            foreach (Leaseholder leaseholder in leaseholders)
            {
                foreach (Preference preference in leaseholder.Preferences)
                {
                    foreach (Preference renterPreference in renter.Preferences)
                    {
                        var renterPreferences = _context.UserPreferences.Where(p => p.UserId == renter.Id).ToList();
                        var leaseholderPreferences = _context.UserPreferences.Where(p => p.UserId == leaseholder.Id).ToList();
                        foreach (UserPreferences userPreference in renterPreferences)
                        {
                            foreach (UserPreferences leasePreference in leaseholderPreferences)
                            {
                                if (userPreference.Id == preference.Id)
                                {
                                    int value = Math.Abs(userPreference.Value - leasePreference.Value);
                                    //Have to return and associate their score with the leaseholder. Array that holds the value and their id maybe?
                                }
                                else
                                    continue;
                                //Truly disgusting code, but should pretty much do what I need
                            }
                        }
                    }
                }
            }


            return finalLeaseholders;
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
