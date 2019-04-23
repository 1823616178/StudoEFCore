﻿// <auto-generated />
using System;
using AspEfCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspEfCore.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190423131739_ManytoManyTwo")]
    partial class ManytoManyTwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AspEfCore.Domain.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaCode");

                    b.Property<string>("Name");

                    b.Property<int>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AspEfCore.Domain.CitiesProvince", b =>
                {
                    b.Property<int>("CitiesId");

                    b.Property<int>("CompanyId");

                    b.Property<int>("Id");

                    b.HasKey("CitiesId", "CompanyId");

                    b.HasIndex("Id");

                    b.ToTable("citiesProvinces");
                });

            modelBuilder.Entity("AspEfCore.Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EstablishDate");

                    b.Property<string>("Name");

                    b.Property<string>("Person");

                    b.HasKey("Id");

                    b.ToTable("companies");
                });

            modelBuilder.Entity("AspEfCore.Domain.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Population");

                    b.HasKey("Id");

                    b.ToTable("provinces");
                });

            modelBuilder.Entity("AspEfCore.Domain.Cities", b =>
                {
                    b.HasOne("AspEfCore.Domain.Province", "Province")
                        .WithMany("Citieses")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspEfCore.Domain.CitiesProvince", b =>
                {
                    b.HasOne("AspEfCore.Domain.Cities", "Cities")
                        .WithMany("CitiesProvinces")
                        .HasForeignKey("CitiesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspEfCore.Domain.Province", "province")
                        .WithMany("CitiesProvinces")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
