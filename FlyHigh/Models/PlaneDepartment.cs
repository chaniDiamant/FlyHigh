using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyHigh.Models
{
    public class PlaneDepartment
    {
        [Key]
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
        public int DepartmentId { get; set; }
        public Department department { get; set; }
    }
}
