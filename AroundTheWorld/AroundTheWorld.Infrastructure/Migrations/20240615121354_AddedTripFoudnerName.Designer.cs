﻿// <auto-generated />
using System;
using AroundTheWorld.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AroundTheWorld.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240615121354_AddedTripFoudnerName")]
    partial class AddedTripFoudnerName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AroundTheWorld.Domain.Entities.CompanionsPair", b =>
                {
                    b.Property<Guid>("FirstCompanion")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SecondCompanion")
                        .HasColumnType("uuid");

                    b.HasKey("FirstCompanion", "SecondCompanion");

                    b.ToTable("Companions");
                });

            modelBuilder.Entity("AroundTheWorld.Domain.Entities.Trip", b =>
                {
                    b.Property<Guid>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("FinishXCoordinate")
                        .HasColumnType("double precision");

                    b.Property<double?>("FinishYCoordinate")
                        .HasColumnType("double precision");

                    b.Property<string>("InvitationLink")
                        .HasColumnType("text");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<int?>("MaxBudget")
                        .HasColumnType("integer");

                    b.Property<int>("MaxPeopleCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("StartXCoordinate")
                        .HasColumnType("double precision");

                    b.Property<double?>("StartYCoordinate")
                        .HasColumnType("double precision");

                    b.Property<string>("TripFounderFullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TripFounderId")
                        .HasColumnType("uuid");

                    b.Property<string>("TripMiniDescription")
                        .HasColumnType("text");

                    b.Property<string>("TripName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TripId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("AroundTheWorld.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AboutMe")
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
