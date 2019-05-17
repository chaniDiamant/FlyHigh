using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FlyHigh.Models
{
    public class Plane
    {
        [DisplayName("מספר מטוס")]
        public int PlaneId { get; set; }

        [DisplayName("שם מטוס")]
        public string Name { get; set; }

        [DisplayName("סוג מטוס")]
        public string Model { get; set; }

        [DisplayName("מספר מושבים")]
        public int NumberOfSeats { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public ICollection<Seat> Seatses { get; set; }

        public ICollection<PlaneDepartment> PlaneDepartments { get; set; }
    }
}
