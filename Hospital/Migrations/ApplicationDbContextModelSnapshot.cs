﻿// <auto-generated />
using System;
using Hospital.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital.Models.Appiontment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Appiontments");
                });

            modelBuilder.Entity("Hospital.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Img = "doctor1.jpg",
                            Name = "Dr. John Smith",
                            Specialization = "Cardiology"
                        },
                        new
                        {
                            Id = 2,
                            Img = "doctor2.jpg",
                            Name = "Dr. Sarah Johnson",
                            Specialization = "Pediatrics"
                        },
                        new
                        {
                            Id = 3,
                            Img = "doctor4.jpg",
                            Name = "Dr. Emily Davis",
                            Specialization = "Dermatology"
                        },
                        new
                        {
                            Id = 4,
                            Img = "doctor3.jpg",
                            Name = "Dr. Michael Lee",
                            Specialization = "Orthopedics"
                        },
                        new
                        {
                            Id = 5,
                            Img = "doctor5.jpg",
                            Name = "Dr. William Clark",
                            Specialization = "Neurology"
                        });
                });

            modelBuilder.Entity("Hospital.Models.Appiontment", b =>
                {
                    b.HasOne("Hospital.Models.Doctor", "Doctor")
                        .WithMany("Appiontments")
                        .HasForeignKey("DoctorId");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Hospital.Models.Doctor", b =>
                {
                    b.Navigation("Appiontments");
                });
#pragma warning restore 612, 618
        }
    }
}
