using FlatMatchApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp
{
    public class Matcher
    {
        //Create algorithm here
        

        public Leaseholder MatchUsers(Renter renter)
        {
            Leaseholder leaseholder = new Leaseholder();

            //Will be a series of values, 1-5, that I will use to match the same values together
            //How to make sure that the list doesn't just choose however may they have in their list of prefs
            //and match [0] to [0], etc., and end up matching two different types of pref?




            return leaseholder;
        }

    }
}
