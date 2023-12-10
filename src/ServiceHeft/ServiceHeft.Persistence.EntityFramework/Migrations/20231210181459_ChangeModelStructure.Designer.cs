﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceHeft.Persistence.EntityFramework.DataAccess;

#nullable disable

namespace ServiceHeft.Persistence.EntityFramework.Migrations
{
    [DbContext(typeof(ServiceHeftDbContext))]
    [Migration("20231210181459_ChangeModelStructure")]
    partial class ChangeModelStructure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServiceHeft.Maintenance.Contracts.Automotive.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DistanceDrivenInKilometers")
                        .HasColumnType("int");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ModelInternalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ModelManufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ProducedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Vin");

                    b.HasIndex("ModelManufacturer", "ModelInternalName");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ServiceHeft.Maintenance.Contracts.Automotive.Model", b =>
                {
                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InternalName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("OfficialName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Manufacturer", "InternalName");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("ServiceHeft.Maintenance.Contracts.Maintenance.Autopart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("OemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid?>("ServiceRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ServiceRecordId");

                    b.ToTable("Autoparts");
                });

            modelBuilder.Entity("ServiceHeft.Maintenance.Contracts.Maintenance.ServiceRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("PerformedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("ServiceRecords");
                });

            modelBuilder.Entity("ServiceHeft.Maintenance.Contracts.Automotive.Car", b =>
                {
                    b.HasOne("ServiceHeft.Maintenance.Contracts.Automotive.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelManufacturer", "ModelInternalName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ServiceHeft.Maintenance.Contracts.Automotive.Engine", "Engine", b1 =>
                        {
                            b1.Property<Guid>("CarId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CylinderVolumeInCubicCentimeters")
                                .HasColumnType("int");

                            b1.Property<int>("FuelType")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("PowerInKilowatts")
                                .HasColumnType("int");

                            b1.HasKey("CarId");

                            b1.ToTable("Cars");

                            b1.WithOwner()
                                .HasForeignKey("CarId");
                        });

                    b.Navigation("Engine")
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ServiceHeft.Maintenance.Contracts.Maintenance.Autopart", b =>
                {
                    b.HasOne("ServiceHeft.Maintenance.Contracts.Maintenance.ServiceRecord", null)
                        .WithMany("PartsChanged")
                        .HasForeignKey("ServiceRecordId");
                });

            modelBuilder.Entity("ServiceHeft.Maintenance.Contracts.Maintenance.ServiceRecord", b =>
                {
                    b.HasOne("ServiceHeft.Maintenance.Contracts.Automotive.Car", null)
                        .WithMany("ServiceRecords")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceHeft.Maintenance.Contracts.Automotive.Car", b =>
                {
                    b.Navigation("ServiceRecords");
                });

            modelBuilder.Entity("ServiceHeft.Maintenance.Contracts.Maintenance.ServiceRecord", b =>
                {
                    b.Navigation("PartsChanged");
                });
#pragma warning restore 612, 618
        }
    }
}
