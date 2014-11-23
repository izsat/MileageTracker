using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MileageTracker.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual EmployeeModel Supervisor { get; set; }
        public virtual ICollection<TripModel> Trips { get; set; }
    }
}