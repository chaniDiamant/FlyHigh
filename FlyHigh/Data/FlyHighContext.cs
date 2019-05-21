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

        public DbSet<FlyHigh.Models.Terminal> Terminal { get; set; }

        public DbSet<FlyHigh.Models.Ticket> Ticket { get; set; }

        public DbSet<FlyHigh.Models.Destination> Destination { get; set; }

        public DbSet<FlyHigh.Models.Flight> Flight { get; set; }

        public DbSet<FlyHigh.Models.Order> Order { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaneDepartment>()
                .HasKey(t => new { t.PlaneId, t.DepartmentName });

            modelBuilder.Entity<PlaneDepartment>()
                .HasOne(pt => pt.Plane)
                .WithMany(p => p.PlaneDepartments)
                .HasForeignKey(pt => pt.PlaneId);

            modelBuilder.Entity<PlaneDepartment>()
                .HasOne(pt => pt.Department)
                .WithMany(t => t.PlaneDepartments)
                .HasForeignKey(pt => pt.DepartmentName);

        }
    }

}

