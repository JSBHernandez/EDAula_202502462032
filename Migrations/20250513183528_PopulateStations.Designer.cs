﻿// <auto-generated />
using System;
using EDAula_202502462032.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EDAula_202502462032.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250513183528_PopulateStations")]
    partial class PopulateStations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EDAula_202502462032.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Luggage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TrainId");

                    b.ToTable("Luggages");
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IdentificationType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Distance")
                        .HasColumnType("double");

                    b.Property<bool>("HasStarted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("IntermediateStations")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Schedule")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("StationId")
                        .HasColumnType("int");

                    b.Property<string>("Train")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Ubicación A",
                            Name = "A"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Ubicación B",
                            Name = "B"
                        },
                        new
                        {
                            Id = 3,
                            Location = "Ubicación C",
                            Name = "C"
                        },
                        new
                        {
                            Id = 4,
                            Location = "Ubicación D",
                            Name = "D"
                        },
                        new
                        {
                            Id = 5,
                            Location = "Ubicación E",
                            Name = "E"
                        },
                        new
                        {
                            Id = 6,
                            Location = "Ubicación F",
                            Name = "F"
                        },
                        new
                        {
                            Id = 7,
                            Location = "Ubicación G",
                            Name = "G"
                        },
                        new
                        {
                            Id = 8,
                            Location = "Ubicación H",
                            Name = "H"
                        },
                        new
                        {
                            Id = 9,
                            Location = "Ubicación I",
                            Name = "I"
                        },
                        new
                        {
                            Id = 10,
                            Location = "Ubicación J",
                            Name = "J"
                        },
                        new
                        {
                            Id = 11,
                            Location = "Ubicación K",
                            Name = "K"
                        });
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SeatCategory")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TrainId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LuggageCapacity")
                        .HasColumnType("int");

                    b.Property<double>("Mileage")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PassengerCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Luggage", b =>
                {
                    b.HasOne("EDAula_202502462032.Models.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDAula_202502462032.Models.Train", "Train")
                        .WithMany()
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Route", b =>
                {
                    b.HasOne("EDAula_202502462032.Models.Station", null)
                        .WithMany("Routes")
                        .HasForeignKey("StationId");
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Ticket", b =>
                {
                    b.HasOne("EDAula_202502462032.Models.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDAula_202502462032.Models.Train", "Train")
                        .WithMany()
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("EDAula_202502462032.Models.Station", b =>
                {
                    b.Navigation("Routes");
                });
#pragma warning restore 612, 618
        }
    }
}
