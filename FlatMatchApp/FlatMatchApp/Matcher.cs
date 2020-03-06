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
        

        public Leaseholder MatchUsers(Renter renter)
        {
            Leaseholder leaseholder = new Leaseholder();

            //Will be a series of values, 1-5, that I will use to match the same values together
            //How to make sure that the list doesn't just choose however may they have in their list of prefs
            //and match [0] to [0], etc., and end up matching two different types of pref?

            //The closer their numbers are, the closer they are to a match.
            //Divide their score by their total number of preferences, the closer they are to 1, the higher
            //that leaseholder shows up on the list?

            //Need returned from the search an array of the full length of the number of search terms, with
            //a 0 or something in each place they didn't check the box?



            return leaseholder;
            //Might want to return a list or IQueryable of leaseholders. Or RedirectToAction("Index", IQueryable<Leaseholder>)
            //or something similar
        }

    }
}
