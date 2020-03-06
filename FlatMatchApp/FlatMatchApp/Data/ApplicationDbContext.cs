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
        }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Leaseholder> Leaseholders { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet <Address> Addresses { get; set; }
        public DbSet <Preference> Preferences { get; set; }
    }
}
