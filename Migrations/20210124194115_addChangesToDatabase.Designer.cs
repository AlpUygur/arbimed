﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using arbimed.Data;

namespace arbimed.Migrations
{
    [DbContext(typeof(ArbimedContext))]
    [Migration("20210124194115_addChangesToDatabase")]
    partial class addChangesToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("arbimed.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("LicenseNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UsedVehicleCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("DriverId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("arbimed.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("DistanceInKilometers")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<decimal>("FuelConsumptionInLitres")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("TripId");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("arbimed.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("AverageFuelConsumptionInLitres")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("LastTripDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlateNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("TotalTravelDistanceInKilometers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("VehicleID");

                    b.ToTable("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
