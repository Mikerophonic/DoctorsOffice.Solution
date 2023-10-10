﻿// <auto-generated />
using System;
using DoctorsOffice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorsOffice.Migrations
{
    [DbContext(typeof(DoctorsOfficeContext))]
    partial class DoctorsOfficeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.Property<int>("DoctorsDoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsPatientId")
                        .HasColumnType("int");

                    b.HasKey("DoctorsDoctorId", "PatientsPatientId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("DoctorPatient");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Specialty")
                        .HasColumnType("longtext");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorPatient", b =>
                {
                    b.Property<int>("DoctorPatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("DoctorPatientId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorsPatients");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.HasOne("DoctorsOffice.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsDoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsOffice.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorPatient", b =>
                {
                    b.HasOne("DoctorsOffice.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsOffice.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}