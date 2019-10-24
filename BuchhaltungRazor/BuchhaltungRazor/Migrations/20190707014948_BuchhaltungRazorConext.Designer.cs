﻿// <auto-generated />
using System;
using BuchhaltungRazor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuchhaltungRazor.Migrations
{
    [DbContext(typeof(BuchhaltungRazorContext))]
    [Migration("20190707014948_BuchhaltungRazorConext")]
    partial class BuchhaltungRazorConext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BuchhaltungRazor.Models.Aufwand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Betrag")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("LadenID");

                    b.Property<string>("Number");

                    b.HasKey("ID");

                    b.HasIndex("LadenID");

                    b.ToTable("Aufwands");
                });

            modelBuilder.Entity("BuchhaltungRazor.Models.AufwandList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AufwandID");

                    b.Property<decimal>("Betrag")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PreisEinheit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Titel");

                    b.HasKey("ID");

                    b.HasIndex("AufwandID");

                    b.ToTable("AufwandListes");
                });

            modelBuilder.Entity("BuchhaltungRazor.Models.Laden", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titel")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Ladens");
                });

            modelBuilder.Entity("BuchhaltungRazor.Models.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AufwandID");

                    b.Property<string>("PrivateSchedule");

                    b.Property<long>("PrivateScheduleSize");

                    b.Property<string>("PublicSchedule");

                    b.Property<long>("PublicScheduleSize");

                    b.Property<string>("Titel");

                    b.Property<DateTime>("UploadDT");

                    b.HasKey("ID");

                    b.HasIndex("AufwandID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("BuchhaltungRazor.Models.Aufwand", b =>
                {
                    b.HasOne("BuchhaltungRazor.Models.Laden")
                        .WithMany("aufwands")
                        .HasForeignKey("LadenID");
                });

            modelBuilder.Entity("BuchhaltungRazor.Models.AufwandList", b =>
                {
                    b.HasOne("BuchhaltungRazor.Models.Aufwand")
                        .WithMany("aufwandslist")
                        .HasForeignKey("AufwandID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuchhaltungRazor.Models.Schedule", b =>
                {
                    b.HasOne("BuchhaltungRazor.Models.Aufwand")
                        .WithMany("schedule")
                        .HasForeignKey("AufwandID");
                });
#pragma warning restore 612, 618
        }
    }
}