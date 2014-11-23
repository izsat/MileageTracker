using MileageTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MileageTracker.DAL
{
    public class TripDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<TripDbContext>
    {
        protected override void Seed(TripDbContext context)
        {
            var employees = new List<EmployeeModel>
            {
                new EmployeeModel {Id=1, FirstName="Quynh", LastName="Van"},
                new EmployeeModel{Id=2, FirstName="Lisa", LastName="Seijas"},
                new EmployeeModel{Id=3, FirstName="Kara", LastName="Pappalardo"},
                new EmployeeModel{Id=4, FirstName="Carrie", LastName="Mathieson"}
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var seedEmployeeQueryResult = from b in context.Employees
                                          where b.FirstName.Equals("Quynh")
                                          select b;

            EmployeeModel seedEmployee = seedEmployeeQueryResult.First();

            var karaEmployeeResult = from b in context.Employees
                                     where b.FirstName.Equals("Kara")
                                     select b;

            EmployeeModel karaEmployee = karaEmployeeResult.First();


            var mileageEntries = new List<TripModel>
            {
                new TripModel{Employee = seedEmployee, StartMileage=100, EndMileage=200, Purpose = "Hospital visit", StartTime = new DateTime(2014,03,30), EndTime = new DateTime(2014,03,31)},
                new TripModel{Employee = seedEmployee, StartMileage=200, EndMileage=300, Purpose = "Follow-up", StartTime = new DateTime(2014,03,30), EndTime = new DateTime(2014,03,31)},
                new TripModel{Employee = seedEmployee, StartMileage=300, EndMileage=400, Purpose = "Interview", StartTime = new DateTime(2014,03,30), EndTime = new DateTime(2014,03,31)},
                new TripModel{Employee = karaEmployee, StartMileage=300, EndMileage=400, Purpose = "Lunch", StartTime = new DateTime(2014,03,30), EndTime = new DateTime(2014,03,31)}
            };

            mileageEntries.ForEach(m => context.Trips.Add(m));
            context.SaveChanges();
            //base.Seed(context);
        }

    }
}
