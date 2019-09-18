﻿// <auto-generated />
using System;
using HypSuite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HypSuite.Data.Migrations
{
    [DbContext(typeof(HypSuiteDBContext))]
    partial class HypSuiteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("ClientGuestsID");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("PartySize");

                    b.HasKey("GuestID");

                    b.HasIndex("ClientGuestsID");

                    b.ToTable("Guests");
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

                    b.Property<int>("ClientLocationsID");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("LocationID");

                    b.HasIndex("ClientLocationsID");

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

                    b.Property<int>("ClientHistoryID");

                    b.Property<int>("GuestID");

                    b.Property<int>("LocationID");

                    b.Property<int>("NumberOfGuests");

                    b.Property<decimal>("Total");

                    b.HasKey("ReservationID");

                    b.HasIndex("ClientHistoryID");

                    b.HasIndex("GuestID");

                    b.HasIndex("LocationID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DailyRate");

                    b.Property<bool>("IsOccupied");

                    b.Property<bool>("IsSmoking");

                    b.Property<int>("LocationRefID");

                    b.Property<int>("MaxCapacity");

                    b.Property<int>("NumberOfBathrooms");

                    b.Property<int>("NumberOfBeds");

                    b.Property<int?>("ReservationRefID");

                    b.Property<int?>("ReservationRefId");

                    b.Property<int>("SizeSqFt");

                    b.HasKey("RoomID");

                    b.HasIndex("LocationRefID");

                    b.HasIndex("ReservationRefId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Guest", b =>
                {
                    b.HasOne("HypSuite.Domain.Models.HotelClient", "Client")
                        .WithMany("GuestList")
                        .HasForeignKey("ClientGuestsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Location", b =>
                {
                    b.HasOne("HypSuite.Domain.Models.HotelClient", "Client")
                        .WithMany("Locations")
                        .HasForeignKey("ClientLocationsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Reservation", b =>
                {
                    b.HasOne("HypSuite.Domain.Models.HotelClient", "Client")
                        .WithMany("ReservationHistory")
                        .HasForeignKey("ClientHistoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HypSuite.Domain.Models.Guest", "Customer")
                        .WithMany()
                        .HasForeignKey("GuestID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HypSuite.Domain.Models.Location", "HotelsLocation")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HypSuite.Domain.Models.Room", b =>
                {
                    b.HasOne("HypSuite.Domain.Models.Location", "Location")
                        .WithMany("Rooms")
                        .HasForeignKey("LocationRefID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HypSuite.Domain.Models.Reservation", "ReservationRef")
                        .WithMany("Rooms")
                        .HasForeignKey("ReservationRefId");
                });
#pragma warning restore 612, 618
        }
    }
}
