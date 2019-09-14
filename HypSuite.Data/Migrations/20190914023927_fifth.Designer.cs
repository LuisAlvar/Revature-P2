﻿// <auto-generated />
using System;
using HypSuite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HypSuite.Data.Migrations
{
    [DbContext(typeof(HypSuiteDBContext))]
    [Migration("20190914023927_fifth")]
    partial class fifth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HypSuite.Domain.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Position")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("EmployeeID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Guest", b =>
                {
                    b.Property<int>("GuestID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int?>("HotelClientClientID");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<int>("ReservationID");

                    b.Property<string>("Username");

                    b.HasKey("GuestID");

                    b.HasIndex("HotelClientClientID");

                    b.HasIndex("ReservationID")
                        .IsUnique();

                    b.ToTable("Guest");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.HotelClient", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.HasKey("ClientID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int?>("HotelClientClientID");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("LocationID");

                    b.HasIndex("HotelClientClientID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CheckInDate")
                        .IsRequired();

                    b.Property<string>("CheckOutDate")
                        .IsRequired();

                    b.Property<int?>("HotelClientClientID");

                    b.Property<int?>("HotelsLocationLocationID");

                    b.Property<int>("NumberOfGuests");

                    b.Property<decimal>("Total");

                    b.HasKey("ReservationID");

                    b.HasIndex("HotelClientClientID");

                    b.HasIndex("HotelsLocationLocationID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DailyRate");

                    b.Property<bool>("IsOccupied");

                    b.Property<bool>("IsSmoking");

                    b.Property<int>("LocationID");

                    b.Property<int>("MaxCapacity");

                    b.Property<int>("NumberOfBathrooms");

                    b.Property<int>("NumberOfBeds");

                    b.Property<int?>("ReservationID");

                    b.Property<int>("SizeSqFt");

                    b.HasKey("RoomID");

                    b.HasIndex("LocationID");

                    b.HasIndex("ReservationID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Guest", b =>
                {
                    b.HasOne("HypSuite.Domain.Models.HotelClient")
                        .WithMany("GuestList")
                        .HasForeignKey("HotelClientClientID");

                    b.HasOne("HypSuite.Domain.Models.Reservation")
                        .WithOne("Customer")
                        .HasForeignKey("HypSuite.Domain.Models.Guest", "ReservationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Location", b =>
                {
                    b.HasOne("HypSuite.Domain.Models.HotelClient")
                        .WithMany("Locations")
                        .HasForeignKey("HotelClientClientID");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Reservation", b =>
                {
                    b.HasOne("HypSuite.Domain.Models.HotelClient")
                        .WithMany("ReservationHistory")
                        .HasForeignKey("HotelClientClientID");

                    b.HasOne("HypSuite.Domain.Models.Location", "HotelsLocation")
                        .WithMany()
                        .HasForeignKey("HotelsLocationLocationID");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Room", b =>
                {
                    b.HasOne("HypSuite.Domain.Models.Location")
                        .WithMany("Rooms")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HypSuite.Domain.Models.Reservation")
                        .WithMany("Rooms")
                        .HasForeignKey("ReservationID");
                });
#pragma warning restore 612, 618
        }
    }
}
