﻿// <auto-generated />
using System;
using ConsoleRpg.Context;
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

            modelBuilder.Entity("ConsoleRpg.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<string>("CharacterType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MaxHealth")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Characters");

                    b.HasDiscriminator<string>("CharacterType").HasValue("Character");

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

            modelBuilder.Entity("ConsoleRpg.Entities.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("MerchantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.HasIndex("LocationId");

                    b.HasIndex("MerchantId");

                    b.HasIndex("QuestId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("ItemType").HasValue("Item");

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

            modelBuilder.Entity("ConsoleRpg.Entities.Npc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NpcType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.ToTable("Npcs");

                    b.HasDiscriminator<string>("NpcType").HasValue("Npc");

                    b.UseTphMappingStrategy();
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

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NpcId")
                        .HasColumnType("int");

                    b.Property<string>("QuestType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("RewardExperience")
                        .HasColumnType("int");

                    b.Property<int>("RewardGold")
                        .HasColumnType("int");

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.HasIndex("NpcId");

                    b.ToTable("Quests");

                    b.HasDiscriminator<string>("QuestType").HasValue("Quest");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ConsoleRpg.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Effects.Effect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("EffectType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int?>("PotionId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PotionId");

                    b.ToTable("Effects");

                    b.HasDiscriminator<string>("EffectType").HasValue("Effect");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ConsoleRpg.Models.Characters.Enemy", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Character");

                    b.Property<int?>("QuestId")
                        .HasColumnType("int");

                    b.HasIndex("QuestId");

                    b.HasDiscriminator().HasValue("Enemy");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Characters.Player", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Character");

                    b.Property<int?>("QuestId")
                        .HasColumnType("int");

                    b.HasIndex("QuestId");

                    b.ToTable("Characters", t =>
                        {
                            t.Property("QuestId")
                                .HasColumnName("Player_QuestId");
                        });

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

                    b.Property<int>("Denomination")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Gold");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Potion", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Item");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsPotable")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Potion");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Shield", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Item");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Shield");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Sword", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Item");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.ToTable("Items", t =>
                        {
                            t.Property("Price")
                                .HasColumnName("Sword_Price");
                        });

                    b.HasDiscriminator().HasValue("Sword");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Npcs.Merchant", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Npc");

                    b.HasDiscriminator().HasValue("Merchant");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Npcs.Types.InformativeNpc", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Npc");

                    b.HasDiscriminator().HasValue("Informative");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Npcs.Types.InteractiveNpc", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Npc");

                    b.HasDiscriminator().HasValue("Interactive");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Quests.FindItemQuest", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Quest");

                    b.Property<string>("TargetItem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FindItem");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Quests.FindLocationQuest", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Quest");

                    b.Property<string>("TargetLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FindLocation");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Quests.FindNpcQuest", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Quest");

                    b.Property<string>("TargetNpc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FindNpc");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Quests.KillEnemiesQuest", b =>
                {
                    b.HasBaseType("ConsoleRpg.Entities.Quest");

                    b.HasDiscriminator().HasValue("KillEnemies");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Effects.BoostAttributeEffect", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Effects.Effect");

                    b.HasDiscriminator().HasValue("BoostAttribute");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Effects.DamageEffect", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Effects.Effect");

                    b.HasDiscriminator().HasValue("Damage");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Effects.HealEffect", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Effects.Effect");

                    b.HasDiscriminator().HasValue("Heal");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Character", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Location", "Location")
                        .WithMany("Characters")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
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

            modelBuilder.Entity("ConsoleRpg.Entities.Inventory", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Character", "Character")
                        .WithOne("Inventory")
                        .HasForeignKey("ConsoleRpg.Entities.Inventory", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Item", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Inventory", "Inventory")
                        .WithMany("Items")
                        .HasForeignKey("InventoryId");

                    b.HasOne("ConsoleRpg.Entities.Location", "Location")
                        .WithMany("Items")
                        .HasForeignKey("LocationId");

                    b.HasOne("ConsoleRpg.Models.Npcs.Merchant", null)
                        .WithMany("Inventory")
                        .HasForeignKey("MerchantId");

                    b.HasOne("ConsoleRpg.Entities.Quest", null)
                        .WithMany("RewardItems")
                        .HasForeignKey("QuestId");

                    b.Navigation("Inventory");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Quest", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Location", "Location")
                        .WithOne("Quest")
                        .HasForeignKey("ConsoleRpg.Entities.Quest", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleRpg.Entities.Npc", "Npc")
                        .WithMany("Quests")
                        .HasForeignKey("NpcId");

                    b.Navigation("Location");

                    b.Navigation("Npc");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.User", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Characters.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Effects.Effect", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Items.Potion", null)
                        .WithMany("Effects")
                        .HasForeignKey("PotionId");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Characters.Enemy", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Quest", "Quest")
                        .WithMany()
                        .HasForeignKey("QuestId");

                    b.Navigation("Quest");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Characters.Player", b =>
                {
                    b.HasOne("ConsoleRpg.Entities.Quest", null)
                        .WithMany("Players")
                        .HasForeignKey("QuestId");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Character", b =>
                {
                    b.Navigation("Inventory")
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Inventory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Location", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Items");

                    b.Navigation("Quest")
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Npc", b =>
                {
                    b.Navigation("DialogueOptions");

                    b.Navigation("Quests");
                });

            modelBuilder.Entity("ConsoleRpg.Entities.Quest", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("RewardItems");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Potion", b =>
                {
                    b.Navigation("Effects");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Npcs.Merchant", b =>
                {
                    b.Navigation("Inventory");
                });
#pragma warning restore 612, 618
        }
    }
}
