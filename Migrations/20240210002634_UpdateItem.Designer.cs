﻿// <auto-generated />
using System;
using ConsoleRpg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleRpg.Migrations
{
    [DbContext(typeof(RpgContext))]
    [Migration("20240210002634_UpdateItem")]
    partial class UpdateItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsoleRpg.Entities.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("MerchantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("MerchantId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Merchant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GoldReward")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("Exit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Exit");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Enemy", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Location", "Location")
                        .WithMany("Enemies")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Item", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Location", "Location")
                        .WithMany("Items")
                        .HasForeignKey("LocationId");

                    b.HasOne("ConsoleRpg.Entities.Merchant", null)
                        .WithMany("Inventory")
                        .HasForeignKey("MerchantId");

                    b.HasOne("ConsoleRpg.Entities.Player", null)
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Quest", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Player", null)
                        .WithMany("ActiveQuests")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Exit", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Location", "Location")
                        .WithMany("Exits")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Location", b =>
                {
                    b.Navigation("Enemies");

                    b.Navigation("Exits");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Merchant", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Player", b =>
                {
                    b.Navigation("ActiveQuests");

                    b.Navigation("Inventory");
                });
#pragma warning restore 612, 618
        }
    }
}
