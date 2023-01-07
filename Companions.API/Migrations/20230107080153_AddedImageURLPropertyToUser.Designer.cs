﻿// <auto-generated />
using System;
using Companions.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Companions.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230107080153_AddedImageURLPropertyToUser")]
    partial class AddedImageURLPropertyToUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Companions.Domain.Activity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActivityTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuddyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("BuddyId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Companions.Domain.ActivityType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActivityTypes");
                });

            modelBuilder.Entity("Companions.Domain.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppointmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppointmentTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuddyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentTypeId");

                    b.HasIndex("BuddyId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Companions.Domain.AppointmentType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppointmentTypes");
                });

            modelBuilder.Entity("Companions.Domain.Buddy", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Buddies");
                });

            modelBuilder.Entity("Companions.Domain.BuddyWeight", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuddyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateWeighed")
                        .HasColumnType("datetime2");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BuddyId");

                    b.ToTable("BuddyWeights");
                });

            modelBuilder.Entity("Companions.Domain.FeedBrand", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FeedBrands");
                });

            modelBuilder.Entity("Companions.Domain.FeedProduct", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrandNameId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandNameId");

                    b.ToTable("FeedProducts");
                });

            modelBuilder.Entity("Companions.Domain.FeedingSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("BuddyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FeedProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TimeOfDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuddyId");

                    b.HasIndex("FeedProductId");

                    b.ToTable("FeedingSchedules");
                });

            modelBuilder.Entity("Companions.Domain.Place", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Companions.Domain.Species", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SpeciesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpeciesRace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("Companions.Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Companions.Domain.Vaccination", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("AmountOfRepeats")
                        .HasColumnType("tinyint");

                    b.Property<string>("BuddyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateFirstVaccination")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuddyId");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("Companions.Domain.Activity", b =>
                {
                    b.HasOne("Companions.Domain.ActivityType", "ActivityType")
                        .WithMany("Activities")
                        .HasForeignKey("ActivityTypeId");

                    b.HasOne("Companions.Domain.Buddy", "Buddy")
                        .WithMany("Activities")
                        .HasForeignKey("BuddyId");

                    b.Navigation("ActivityType");

                    b.Navigation("Buddy");
                });

            modelBuilder.Entity("Companions.Domain.Appointment", b =>
                {
                    b.HasOne("Companions.Domain.AppointmentType", "AppointmentType")
                        .WithMany("Appointments")
                        .HasForeignKey("AppointmentTypeId");

                    b.HasOne("Companions.Domain.Buddy", "Buddy")
                        .WithMany("Appointments")
                        .HasForeignKey("BuddyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Companions.Domain.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");

                    b.Navigation("AppointmentType");

                    b.Navigation("Buddy");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Companions.Domain.Buddy", b =>
                {
                    b.HasOne("Companions.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Companions.Domain.BuddyWeight", b =>
                {
                    b.HasOne("Companions.Domain.Buddy", "Buddy")
                        .WithMany("BuddyWeights")
                        .HasForeignKey("BuddyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buddy");
                });

            modelBuilder.Entity("Companions.Domain.FeedProduct", b =>
                {
                    b.HasOne("Companions.Domain.FeedBrand", "BrandName")
                        .WithMany("FeedProducts")
                        .HasForeignKey("BrandNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BrandName");
                });

            modelBuilder.Entity("Companions.Domain.FeedingSchedule", b =>
                {
                    b.HasOne("Companions.Domain.Buddy", null)
                        .WithMany("FeedingSchedules")
                        .HasForeignKey("BuddyId");

                    b.HasOne("Companions.Domain.FeedProduct", "FeedProduct")
                        .WithMany()
                        .HasForeignKey("FeedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeedProduct");
                });

            modelBuilder.Entity("Companions.Domain.Vaccination", b =>
                {
                    b.HasOne("Companions.Domain.Buddy", "Buddy")
                        .WithMany("Vaccinations")
                        .HasForeignKey("BuddyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buddy");
                });

            modelBuilder.Entity("Companions.Domain.ActivityType", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("Companions.Domain.AppointmentType", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Companions.Domain.Buddy", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Appointments");

                    b.Navigation("BuddyWeights");

                    b.Navigation("FeedingSchedules");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("Companions.Domain.FeedBrand", b =>
                {
                    b.Navigation("FeedProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
