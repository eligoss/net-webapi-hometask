﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.HomeTask.Dal;

#nullable disable

namespace WebApi.HomeTask.Dal.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20220824073149_UpdateTableSize")]
    partial class UpdateTableSize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.LocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.ReservationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("EndTimeEpoch")
                        .HasColumnType("bigint");

                    b.Property<string>("OwnerFullName")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("OwnerPhone")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<long>("StartTimeEpoch")
                        .HasColumnType("bigint");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("TableSizeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.HasIndex("TableSizeId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.RestaurantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("CloseTime")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<long>("OpenTime")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.RestaurantTablesSummaryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<short>("Amount")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("TableSizeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableSizeId");

                    b.ToTable("RestaurantTablesSummary");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.TableEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("TableEntityId")
                        .HasColumnType("int");

                    b.Property<int>("TableSizeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableEntityId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.TableSizeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PeopleCount")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("PeopleCount");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("PeopleCount"), new[] { "Size" });

                    b.HasIndex("Size");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("Size"), new[] { "PeopleCount" });

                    b.ToTable("TablesSize");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.LocationEntity", b =>
                {
                    b.HasOne("WebApi.HomeTask.Dal.Entities.RestaurantEntity", "Restaurant")
                        .WithMany("Locations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.ReservationEntity", b =>
                {
                    b.HasOne("WebApi.HomeTask.Dal.Entities.RestaurantEntity", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.HomeTask.Dal.Entities.TableEntity", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApi.HomeTask.Dal.Entities.TableSizeEntity", "TableSize")
                        .WithMany("Reservations")
                        .HasForeignKey("TableSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("Table");

                    b.Navigation("TableSize");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.RestaurantTablesSummaryEntity", b =>
                {
                    b.HasOne("WebApi.HomeTask.Dal.Entities.RestaurantEntity", "Restaurant")
                        .WithMany("TablesSummary")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.HomeTask.Dal.Entities.TableSizeEntity", "TableSize")
                        .WithMany("RestaurantTablesSummary")
                        .HasForeignKey("TableSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("TableSize");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.TableEntity", b =>
                {
                    b.HasOne("WebApi.HomeTask.Dal.Entities.LocationEntity", "Location")
                        .WithMany("Tables")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.HomeTask.Dal.Entities.RestaurantEntity", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApi.HomeTask.Dal.Entities.TableSizeEntity", "TableSize")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.HomeTask.Dal.Entities.TableEntity", null)
                        .WithMany("Tables")
                        .HasForeignKey("TableEntityId");

                    b.Navigation("Location");

                    b.Navigation("Restaurant");

                    b.Navigation("TableSize");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.LocationEntity", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.RestaurantEntity", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");

                    b.Navigation("TablesSummary");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.TableEntity", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("WebApi.HomeTask.Dal.Entities.TableSizeEntity", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("RestaurantTablesSummary");

                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
