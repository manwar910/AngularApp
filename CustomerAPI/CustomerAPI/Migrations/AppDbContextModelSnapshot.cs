﻿// <auto-generated />
using System;
using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CreatedDate = new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "muhammad@gmail.com",
                            FirstName = "Muhammad",
                            LastName = "Abdullah",
                            LastUpdatedDate = new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 2,
                            CreatedDate = new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tauqeeranwar@gmail.com",
                            FirstName = "Touqeer",
                            LastName = "Anwar",
                            LastUpdatedDate = new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 3,
                            CreatedDate = new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mustafaanwar@gmail.com",
                            FirstName = "Mustafa",
                            LastName = "Anwar",
                            LastUpdatedDate = new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 4,
                            CreatedDate = new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ahmad@gmail.com",
                            FirstName = "Ahmad",
                            LastName = "Abdullah",
                            LastUpdatedDate = new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
