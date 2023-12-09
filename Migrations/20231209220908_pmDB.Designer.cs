﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagementApi.Data;

#nullable disable

namespace ProjectManagementApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231209220908_pmDB")]
    partial class pmDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectManagementApi.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Ended")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("TimePassed")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("WorkTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2515),
                            CreatedById = 2,
                            Deadline = new DateTime(2023, 12, 29, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2531),
                            Description = "Build a pod for the rocket to start",
                            LastEdited = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2525),
                            Name = "Build a starting pod",
                            Priority = 3,
                            ProjectId = 1,
                            Status = 0
                        });
                });

            modelBuilder.Entity("ProjectManagementApi.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Ended")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("TimePassed")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("WorkTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2428),
                            CreatedById = 2,
                            Deadline = new DateTime(2024, 3, 18, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2451),
                            Description = "Building a spaceship that will get us to Mars",
                            LastEdited = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2443),
                            Name = "Spaceship to Mars",
                            Priority = 2,
                            Status = 0
                        });
                });

            modelBuilder.Entity("ProjectManagementApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Avatar = "",
                            Created = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2030),
                            FirstName = "Rick",
                            LastEdited = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2087),
                            LastName = "Sanchez",
                            Login = "sancheezium",
                            Password = "1234",
                            UserType = 0
                        },
                        new
                        {
                            Id = 2,
                            Avatar = "",
                            Created = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2098),
                            FirstName = "Morty",
                            LastEdited = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2105),
                            LastName = "Smith",
                            Login = "morty",
                            Password = "1234",
                            UserType = 1
                        },
                        new
                        {
                            Id = 3,
                            Avatar = "",
                            Created = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2113),
                            FirstName = "Summer",
                            LastEdited = new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2120),
                            LastName = "Smith",
                            Login = "sumsum",
                            Password = "1234",
                            UserType = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}