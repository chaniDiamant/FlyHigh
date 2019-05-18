using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlyHigh.Models;

namespace FlyHigh.Models
{
    public class FlyHighContext : DbContext
    {
        public FlyHighContext (DbContextOptions<FlyHighContext> options)
            : base(options)
        {
        }

        public DbSet<FlyHigh.Models.Department> Department { get; set; }

        public DbSet<FlyHigh.Models.Seat> Seat { get; set; }

        public DbSet<FlyHigh.Models.PlaneDepartment> PlaneDepartment { get; set; }

        public DbSet<FlyHigh.Models.Customer> Customer { get; set; }

        public DbSet<FlyHigh.Models.Plane> Plane { get; set; }
    }
}
