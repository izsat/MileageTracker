using MileageTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MileageTracker.DAL
{
    public class TripDbContext : DbContext
    {
        public TripDbContext() : base("name=TripDb")
        {
            Database.SetInitializer<TripDbContext>(new TripDbInitializer());
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<TripModel> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Make table names singular instead of plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}