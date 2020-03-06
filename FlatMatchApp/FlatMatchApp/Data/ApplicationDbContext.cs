using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FlatMatchApp.Models;

namespace FlatMatchApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Name = "Renter",
                        NormalizedName = "RENTER"
                    }, new IdentityRole
                    {
                        Name = "Leaseholder",
                        NormalizedName = "LEASEHOLDER"
                    }

                );

            builder.Entity<Preference>().HasData(
                    new Preference { Id = 1, Name = "Activity"},
                    new Preference { Id = 2, Name = "Smoking"},
                    new Preference { Id = 3, Name = "Drinking" },
                    new Preference { Id = 4, Name = "Bedtime" },
                    new Preference { Id = 5, Name = "Noise Level" },
                    new Preference { Id = 6, Name = "Washer/Dryer" },
                    new Preference { Id = 7, Name = "GymInBuilding" },
                    new Preference { Id = 8, Name = "Cleanliness" },
                    new Preference { Id = 9, Name = "Food" },
                    new Preference { Id = 10, Name = "Extravert/Introvert" }
                    //Can add an Importance property if time so the user can weight according to what matters most to them
                );
        }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Leaseholder> Leaseholders { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet <Address> Addresses { get; set; }
        public DbSet <Preference> Preferences { get; set; }
        public DbSet<UserPreferences> UserPreferences { get; set; }
    }
}
