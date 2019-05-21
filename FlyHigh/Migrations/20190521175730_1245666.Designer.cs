﻿// <auto-generated />
using FlyHigh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FlyHigh.Migrations
{
    [DbContext(typeof(FlyHighContext))]
    [Migration("20190521175730_1245666")]
    partial class _1245666
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlyHigh.Models.Customer", b =>
                {
                    b.Property<int>("Passport")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<int>("Phone");

                    b.HasKey("Passport");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("FlyHigh.Models.Department", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("ExtraPrice");

                    b.HasKey("Name");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("FlyHigh.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrencyValue");

                    b.Property<string>("Language");

                    b.Property<string>("Name");

                    b.HasKey("DestinationId");

                    b.ToTable("Destination");
                });

            modelBuilder.Entity("FlyHigh.Models.Flight", b =>
                {
                    b.Property<int>("FlightNumber");

                    b.Property<int?>("DestinationId");

                    b.Property<DateTime>("Landing");

                    b.Property<int?>("PlaneId");

                    b.Property<float>("Price");

                    b.Property<DateTime>("TakeOff");

                    b.Property<string>("TerminalName");

                    b.HasKey("FlightNumber");

                    b.HasIndex("DestinationId");

                    b.HasIndex("PlaneId");

                    b.HasIndex("TerminalName");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("FlyHigh.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerPassport");

                    b.Property<DateTime>("Date");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerPassport");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("FlyHigh.Models.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfSeats");

                    b.HasKey("PlaneId");

                    b.ToTable("Plane");
                });

            modelBuilder.Entity("FlyHigh.Models.PlaneDepartment", b =>
                {
                    b.Property<int>("PlaneId");

                    b.Property<string>("DepartmentName");

                    b.HasKey("PlaneId", "DepartmentName");

                    b.HasIndex("DepartmentName");

                    b.ToTable("PlaneDepartment");
                });

            modelBuilder.Entity("FlyHigh.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PlaneId");

                    b.Property<int?>("TicketNumber");

                    b.HasKey("SeatId");

                    b.HasIndex("PlaneId");

                    b.HasIndex("TicketNumber");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("FlyHigh.Models.Terminal", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Name");

                    b.ToTable("Terminal");
                });

            modelBuilder.Entity("FlyHigh.Models.Ticket", b =>
                {
                    b.Property<int>("TicketNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerPassport");

                    b.Property<string>("DepartmentName");

                    b.Property<int?>("FlightNumber");

                    b.Property<DateTime>("LandingDate");

                    b.Property<int?>("OrderId");

                    b.Property<DateTime>("TakeOffTime");

                    b.Property<string>("TerminalName");

                    b.HasKey("TicketNumber");

                    b.HasIndex("CustomerPassport");

                    b.HasIndex("DepartmentName");

                    b.HasIndex("FlightNumber");

                    b.HasIndex("OrderId");

                    b.HasIndex("TerminalName");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("FlyHigh.Models.Flight", b =>
                {
                    b.HasOne("FlyHigh.Models.Destination", "Destination")
                        .WithMany("Flights")
                        .HasForeignKey("DestinationId");

                    b.HasOne("FlyHigh.Models.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneId");

                    b.HasOne("FlyHigh.Models.Terminal", "Terminal")
                        .WithMany("Flights")
                        .HasForeignKey("TerminalName");
                });

            modelBuilder.Entity("FlyHigh.Models.Order", b =>
                {
                    b.HasOne("FlyHigh.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerPassport");
                });

            modelBuilder.Entity("FlyHigh.Models.PlaneDepartment", b =>
                {
                    b.HasOne("FlyHigh.Models.Department", "Department")
                        .WithMany("PlaneDepartments")
                        .HasForeignKey("DepartmentName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlyHigh.Models.Plane", "Plane")
                        .WithMany("PlaneDepartments")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlyHigh.Models.Seat", b =>
                {
                    b.HasOne("FlyHigh.Models.Plane", "Plane")
                        .WithMany("Seatses")
                        .HasForeignKey("PlaneId");

                    b.HasOne("FlyHigh.Models.Ticket", "Ticket")
                        .WithMany("Seats")
                        .HasForeignKey("TicketNumber");
                });

            modelBuilder.Entity("FlyHigh.Models.Ticket", b =>
                {
                    b.HasOne("FlyHigh.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerPassport");

                    b.HasOne("FlyHigh.Models.Department", "Department")
                        .WithMany("Tickets")
                        .HasForeignKey("DepartmentName");

                    b.HasOne("FlyHigh.Models.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightNumber");

                    b.HasOne("FlyHigh.Models.Order", "Order")
                        .WithMany("Tickets")
                        .HasForeignKey("OrderId");

                    b.HasOne("FlyHigh.Models.Terminal", "Terminal")
                        .WithMany("Tickets")
                        .HasForeignKey("TerminalName");
                });
#pragma warning restore 612, 618
        }
    }
}
