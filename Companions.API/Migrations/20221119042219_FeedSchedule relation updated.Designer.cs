﻿// <auto-generated />
using System;
using Companions.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Companions.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221119042219_FeedSchedule relation updated")]
    partial class FeedSchedulerelationupdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ActivityBuddy", b =>
                {
                    b.Property<string>("ActivitiesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuddiesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ActivitiesId", "BuddiesId");

                    b.HasIndex("BuddiesId");

                    b.ToTable("ActivityBuddy");
                });

            modelBuilder.Entity("AppointmentBuddy", b =>
                {
                    b.Property<string>("AppointmentsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuddiesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AppointmentsId", "BuddiesId");

                    b.HasIndex("BuddiesId");

                    b.ToTable("AppointmentBuddy");
                });

            modelBuilder.Entity("Companions.Domain.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Companions.Domain.Activity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActivityTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Companions.Domain.ActivityType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActivityTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActivityTypes");
                });

            modelBuilder.Entity("Companions.Domain.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AppoinmentDueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppointmentTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentTypeId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Companions.Domain.AppointmentType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppointmentTypes");
                });

            modelBuilder.Entity("Companions.Domain.Buddy", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpeciesId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("SpeciesId");

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

            modelBuilder.Entity("Companions.Domain.DailyFeedingEvents", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuddyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedingScheduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BuddyId");

                    b.HasIndex("FeedingScheduleId");

                    b.ToTable("DailyFeedingEvents");
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

                    b.Property<string>("FeedBrandId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeedBrandId");

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

            modelBuilder.Entity("ActivityBuddy", b =>
                {
                    b.HasOne("Companions.Domain.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Companions.Domain.Buddy", null)
                        .WithMany()
                        .HasForeignKey("BuddiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppointmentBuddy", b =>
                {
                    b.HasOne("Companions.Domain.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Companions.Domain.Buddy", null)
                        .WithMany()
                        .HasForeignKey("BuddiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Companions.Domain.Activity", b =>
                {
                    b.HasOne("Companions.Domain.ActivityType", "ActivityType")
                        .WithMany("Activities")
                        .HasForeignKey("ActivityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityType");
                });

            modelBuilder.Entity("Companions.Domain.Appointment", b =>
                {
                    b.HasOne("Companions.Domain.AppointmentType", "AppointmentType")
                        .WithMany("Appointments")
                        .HasForeignKey("AppointmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentType");
                });

            modelBuilder.Entity("Companions.Domain.Buddy", b =>
                {
                    b.HasOne("Companions.Domain.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Companions.Domain.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Species");
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

            modelBuilder.Entity("Companions.Domain.DailyFeedingEvents", b =>
                {
                    b.HasOne("Companions.Domain.Buddy", "Buddy")
                        .WithMany("DailyFeedingEvents")
                        .HasForeignKey("BuddyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Companions.Domain.FeedingSchedule", "FeedingSchedule")
                        .WithMany()
                        .HasForeignKey("FeedingScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buddy");

                    b.Navigation("FeedingSchedule");
                });

            modelBuilder.Entity("Companions.Domain.FeedProduct", b =>
                {
                    b.HasOne("Companions.Domain.FeedBrand", "FeedBrand")
                        .WithMany("FeedProducts")
                        .HasForeignKey("FeedBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeedBrand");
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
                    b.Navigation("BuddyWeights");

                    b.Navigation("DailyFeedingEvents");

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
