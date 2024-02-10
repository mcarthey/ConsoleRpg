﻿// <auto-generated />
using System;
using ConsoleRpg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleRpg.Migrations
{
    [DbContext(typeof(RpgContext))]
    partial class RpgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsoleRpg.Entities.DialogueOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NpcId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NpcId");

                    b.ToTable("DialogueOptions");
                });

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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MaxHealth")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("QuestId");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Exit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DestinationLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationLocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("Exits");
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

            modelBuilder.Entity("ConsoleRpg.Entities.Npc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Npcs");
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

                    b.Property<int>("MaxHealth")
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

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("KillCount")
                        .HasColumnType("int");

                    b.Property<int>("KillCountProgress")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NpcId")
                        .HasColumnType("int");

                    b.Property<int>("RewardExperience")
                        .HasColumnType("int");

                    b.Property<int>("RewardGold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique()
                        .HasFilter("[LocationId] IS NOT NULL");

                    b.HasIndex("NpcId");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("PlayerQuests", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("QuestId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "QuestId");

                    b.HasIndex("QuestId");

                    b.ToTable("PlayerQuests");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.DialogueOption", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Npc", "Npc")
                        .WithMany("DialogueOptions")
                        .HasForeignKey("NpcId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Npc");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Enemy", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Location", "Location")
                        .WithMany("Enemies")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleRpg.Entities.Quest", "Quest")
                        .WithMany()
                        .HasForeignKey("QuestId");

                    b.Navigation("Location");

                    b.Navigation("Quest");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Exit", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Location", "DestinationLocation")
                        .WithMany()
                        .HasForeignKey("DestinationLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConsoleRpg.Entities.Location", "Location")
                        .WithMany("Exits")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DestinationLocation");

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
                    b.HasOne("ConsoleRpg.Entities.Location", "Location")
                        .WithOne("Quest")
                        .HasForeignKey("ConsoleRpg.Entities.Quest", "LocationId");

                    b.HasOne("ConsoleRpg.Entities.Npc", "Npc")
                        .WithMany("Quests")
                        .HasForeignKey("NpcId");

                    b.Navigation("Location");

                    b.Navigation("Npc");
                });

            modelBuilder.Entity("PlayerQuests", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleRpg.Entities.Quest", null)
                        .WithMany()
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Location", b =>
                {
                    b.Navigation("Enemies");

                    b.Navigation("Exits");

                    b.Navigation("Items");

                    b.Navigation("Quest")
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Merchant", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Npc", b =>
                {
                    b.Navigation("DialogueOptions");

                    b.Navigation("Quests");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Player", b =>
                {
                    b.Navigation("Inventory");
                });
#pragma warning restore 612, 618
        }
    }
}
