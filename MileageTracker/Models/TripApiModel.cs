using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MileageTracker.Models
{
    public class TripApiModel
    {
        public int Id { get; set; }

        public int StartMileage { get; set; }

        public int EndMileage { get; set; }

        public virtual LocationModel StartLocation { get; set; }
        public virtual LocationModel EndLocation { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Purpose { get; set; }
        public int EmployeeId { get; set; }
    }
}