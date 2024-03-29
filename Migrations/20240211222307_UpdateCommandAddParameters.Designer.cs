﻿// <auto-generated />
using System;
using ConsoleRpg.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleRpg.Migrations
{
    [DbContext(typeof(RpgContext))]
    [Migration("20240211222307_UpdateCommandAddParameters")]
    partial class UpdateCommandAddParameters
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

            modelBuilder.Entity("ConsoleRpg.Entities.Character", b =>
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("MaxHealth")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Character");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parameters")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Commands");
                });

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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("LootTableId")
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

                    b.HasIndex("LootTableId");

                    b.HasIndex("MerchantId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");

                    b.UseTphMappingStrategy();
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

            modelBuilder.Entity("ConsoleRpg.Entities.LootTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EnemyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnemyId")
                        .IsUnique()
                        .HasFilter("[EnemyId] IS NOT NULL");

                    b.ToTable("LootTables");
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

            modelBuilder.Entity("ConsoleRpg.Entities.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

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

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique()
                        .HasFilter("[LocationId] IS NOT NULL");

                    b.HasIndex("NpcId");

                    b.ToTable("Quests");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Quest");

                    b.UseTphMappingStrategy();
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

            modelBuilder.Entity("ConsoleRpg.Models.Characters.Enemy", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Character");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("LootTableId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestId")
                        .HasColumnType("int");

                    b.HasIndex("LocationId");

                    b.HasIndex("QuestId");

                    b.HasDiscriminator().HasValue("Enemy");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Characters.Player", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Character");

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Player");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.GeneralItem", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Item");

                    b.HasDiscriminator().HasValue("GeneralItem");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Gold", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Item");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId1")
                        .HasColumnType("int");

                    b.HasIndex("PlayerId1");

                    b.HasDiscriminator().HasValue("Gold");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Potion", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Item");

                    b.Property<int>("Healing")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId1")
                        .HasColumnType("int");

                    b.HasIndex("PlayerId1");

                    b.ToTable("Items", t =>
                        {
                            t.Property("PlayerId1")
                                .HasColumnName("Potion_PlayerId1");
                        });

                    b.HasDiscriminator().HasValue("Potion");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Shield", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Item");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId1")
                        .HasColumnType("int");

                    b.HasIndex("PlayerId1");

                    b.ToTable("Items", t =>
                        {
                            t.Property("PlayerId1")
                                .HasColumnName("Shield_PlayerId1");
                        });

                    b.HasDiscriminator().HasValue("Shield");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Sword", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Item");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId1")
                        .HasColumnType("int");

                    b.HasIndex("PlayerId1");

                    b.ToTable("Items", t =>
                        {
                            t.Property("PlayerId1")
                                .HasColumnName("Sword_PlayerId1");
                        });

                    b.HasDiscriminator().HasValue("Sword");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Quests.FindItemQuest", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Quest");

                    b.Property<string>("TargetItem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FindItemQuest");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Quests.FindLocationQuest", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Quest");

                    b.Property<string>("TargetLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FindLocationQuest");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Quests.FindNpcQuest", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Quest");

                    b.Property<string>("TargetNpc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FindNpcQuest");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Quests.KillEnemiesQuest", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Quest");

                    b.HasDiscriminator().HasValue("KillEnemiesQuest");
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

                    b.HasOne("ConsoleRpg.Entities.LootTable", null)
                        .WithMany("Items")
                        .HasForeignKey("LootTableId");

                    b.HasOne("ConsoleRpg.Entities.Merchant", null)
                        .WithMany("Inventory")
                        .HasForeignKey("MerchantId");

                    b.HasOne("ConsoleRpg.Models.Characters.Player", "Player")
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Location");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.LootTable", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Characters.Enemy", "Enemy")
                        .WithOne("LootTable")
                        .HasForeignKey("ConsoleRpg.Entities.LootTable", "EnemyId");

                    b.Navigation("Enemy");
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
                    b.HasOne("ConsoleRpg.Models.Characters.Player", null)
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

            modelBuilder.Entity("ConsoleRpg.Models.Characters.Enemy", b =>
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

            modelBuilder.Entity("ConsoleRpg.Models.Items.Gold", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Characters.Player", null)
                        .WithMany("Golds")
                        .HasForeignKey("PlayerId1");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Potion", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Characters.Player", null)
                        .WithMany("Potions")
                        .HasForeignKey("PlayerId1");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Shield", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Characters.Player", null)
                        .WithMany("Shields")
                        .HasForeignKey("PlayerId1");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Sword", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Characters.Player", null)
                        .WithMany("Swords")
                        .HasForeignKey("PlayerId1");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Location", b =>
                {
                    b.Navigation("Enemies");

                    b.Navigation("Exits");

                    b.Navigation("Items");

                    b.Navigation("Quest")
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleRpg.Entities.LootTable", b =>
                {
                    b.Navigation("Items");
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

            modelBuilder.Entity("ConsoleRpg.Models.Characters.Enemy", b =>
                {
                    b.Navigation("LootTable");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Characters.Player", b =>
                {
                    b.Navigation("Golds");

                    b.Navigation("Inventory");

                    b.Navigation("Potions");

                    b.Navigation("Shields");

                    b.Navigation("Swords");
                });
#pragma warning restore 612, 618
        }
    }
}
