﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Trips.Core.Infrastructure;

#nullable disable

namespace Trips.Core.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Trips.Core.Domain.Entities.Trip", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("ApprovedByTripCurator")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("ApprovedEmployeeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfModification")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Goal")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("VehicleType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Trips", (string)null);
                });

            modelBuilder.Entity("Trips.Core.Domain.Entities.TripLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfModification")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ObjectId")
                        .HasColumnType("text");

                    b.Property<long>("TripId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripLocations", (string)null);
                });

            modelBuilder.Entity("Trips.Core.Domain.Entities.TripParticipant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfModification")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<long>("TripId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripParticipants", (string)null);
                });

            modelBuilder.Entity("Trips.Core.Domain.Entities.TripLocation", b =>
                {
                    b.HasOne("Trips.Core.Domain.Entities.Trip", null)
                        .WithMany("Locations")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Trips.Core.Domain.Entities.TripParticipant", b =>
                {
                    b.HasOne("Trips.Core.Domain.Entities.Trip", null)
                        .WithMany("Participants")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Trips.Core.Domain.Entities.Trip", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
