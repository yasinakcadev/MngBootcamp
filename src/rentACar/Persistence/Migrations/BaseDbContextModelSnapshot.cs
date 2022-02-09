﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Abstarct.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Brand", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mercedes"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarState")
                        .HasColumnType("int")
                        .HasColumnName("State");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int")
                        .HasColumnName("ColorId");

                    b.Property<int>("CurrentIndicatorValueAsKilometer")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<short>("MinFindexScore")
                        .HasColumnType("smallint");

                    b.Property<int>("ModelId")
                        .HasColumnType("int")
                        .HasColumnName("ModelId");

                    b.Property<short>("ModelYear")
                        .HasColumnType("smallint")
                        .HasColumnName("ModelYear");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Plate");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ColorId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ModelId");

                    b.ToTable("Cars", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarState = 1,
                            CityId = 1,
                            ColorId = 1,
                            CurrentIndicatorValueAsKilometer = 100,
                            MinFindexScore = (short)300,
                            ModelId = 1,
                            ModelYear = (short)2018,
                            Plate = "06ABC06"
                        },
                        new
                        {
                            Id = 2,
                            CarState = 1,
                            CityId = 1,
                            ColorId = 2,
                            CurrentIndicatorValueAsKilometer = 10,
                            MinFindexScore = (short)500,
                            ModelId = 2,
                            ModelYear = (short)2018,
                            Plate = "34ABC34"
                        });
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "istanbul"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ankara"
                        },
                        new
                        {
                            Id = 3,
                            Name = "izmir"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Colors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Blue"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Damage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasColumnName("CarId");

                    b.Property<string>("DamageDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DamageDetail");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Damage", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Fuel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Fuels", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Diesel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Electric"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDate");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerId");

                    b.Property<int>("InvoiceNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentEndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RentEndDate");

                    b.Property<DateTime>("RentStartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RentStartDate");

                    b.Property<double>("TotalRentAmount")
                        .HasColumnType("float")
                        .HasColumnName("TotalRentAmount");

                    b.Property<int>("TotalRentDay")
                        .HasColumnType("int")
                        .HasColumnName("TotalRentDay");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("BrandId");

                    b.Property<double>("DailyPrice")
                        .HasColumnType("float")
                        .HasColumnName("DailyPrice");

                    b.Property<int>("FuelId")
                        .HasColumnType("int")
                        .HasColumnName("FuelId");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("TransmissionId")
                        .HasColumnType("int")
                        .HasColumnName("TransmissionId");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("FuelId");

                    b.HasIndex("TransmissionId");

                    b.ToTable("Models", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            DailyPrice = 1000.0,
                            FuelId = 1,
                            ImageUrl = "",
                            Name = "418i",
                            TransmissionId = 2
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            DailyPrice = 600.0,
                            FuelId = 1,
                            ImageUrl = "",
                            Name = "CLA 180D",
                            TransmissionId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EndIndicatorValueAsKilometer")
                        .HasColumnType("int");

                    b.Property<int?>("GivingCityId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StartIndicatorValueAsKilometer")
                        .HasColumnType("int");

                    b.Property<int?>("TakingCityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("GivingCityId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("TakingCityId");

                    b.ToTable("Rent", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Transmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Tranmissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Manuel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Automatic"
                        });
                });

            modelBuilder.Entity("Domain.FindexScore.FindexScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerId");

                    b.Property<short>("Score")
                        .HasColumnType("smallint")
                        .HasColumnName("Score");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("FindexScores", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CorporateCustomer", b =>
                {
                    b.HasBaseType("Domain.Entities.Abstarct.Customer");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyName");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TaxNumber");

                    b.ToTable("CorporateCustomer", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.IndividualCustomer", b =>
                {
                    b.HasBaseType("Domain.Entities.Abstarct.Customer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Lastname");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NationalId");

                    b.ToTable("IndividualCustomer", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.City", "City")
                        .WithMany("Cars")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Color", "Color")
                        .WithMany("Cars")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Invoice", null)
                        .WithMany("Cars")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Domain.Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Color");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Domain.Entities.Damage", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Domain.Entities.Invoice", b =>
                {
                    b.HasOne("Domain.Entities.Abstarct.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
                {
                    b.HasOne("Domain.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Fuel", "Fuel")
                        .WithMany("Models")
                        .HasForeignKey("FuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Transmission", "Transmission")
                        .WithMany("Models")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Fuel");

                    b.Navigation("Transmission");
                });

            modelBuilder.Entity("Domain.Entities.Rent", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.City", "GivingCity")
                        .WithMany()
                        .HasForeignKey("GivingCityId");

                    b.HasOne("Domain.Entities.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.City", "TakingCity")
                        .WithMany()
                        .HasForeignKey("TakingCityId");

                    b.Navigation("Car");

                    b.Navigation("GivingCity");

                    b.Navigation("Invoice");

                    b.Navigation("TakingCity");
                });

            modelBuilder.Entity("Domain.FindexScore.FindexScore", b =>
                {
                    b.HasOne("Domain.Entities.Abstarct.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.CorporateCustomer", b =>
                {
                    b.HasOne("Domain.Entities.Abstarct.Customer", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.CorporateCustomer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.IndividualCustomer", b =>
                {
                    b.HasOne("Domain.Entities.Abstarct.Customer", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.IndividualCustomer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.Color", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.Fuel", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Domain.Entities.Invoice", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.Transmission", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
