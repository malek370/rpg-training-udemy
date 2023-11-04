﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rpg_training.DBContext;

#nullable disable

namespace rpg_training.Migrations
{
    [DbContext(typeof(appDBcontext))]
    [Migration("20231104172613_addFights")]
    partial class addFights
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterSkill", b =>
                {
                    b.Property<int>("Charactersid")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("Charactersid", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("CharacterSkill");
                });

            modelBuilder.Entity("rpg_training.Models.Character", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Hitpoints")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("loss")
                        .HasColumnType("int");

                    b.Property<int>("wins")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("characters");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Class = 2,
                            Defense = 10,
                            Hitpoints = 100,
                            Intelligence = 10,
                            Name = "Slim",
                            Strength = 10,
                            loss = 0,
                            wins = 0
                        },
                        new
                        {
                            id = 2,
                            Class = 1,
                            Defense = 10,
                            Hitpoints = 100,
                            Intelligence = 10,
                            Name = "chaima",
                            Strength = 10,
                            loss = 0,
                            wins = 0
                        },
                        new
                        {
                            id = 3,
                            Class = 3,
                            Defense = 10,
                            Hitpoints = 100,
                            Intelligence = 10,
                            Name = "Mariem",
                            Strength = 10,
                            loss = 0,
                            wins = 0
                        });
                });

            modelBuilder.Entity("rpg_training.Models.FightRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<int>("charachterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("fightRequests");
                });

            modelBuilder.Entity("rpg_training.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Damage = 20,
                            Name = "fire ball"
                        },
                        new
                        {
                            Id = 2,
                            Damage = 200,
                            Name = "8 gates"
                        },
                        new
                        {
                            Id = 3,
                            Damage = 33,
                            Name = "shadow clone"
                        },
                        new
                        {
                            Id = 4,
                            Damage = 10,
                            Name = "rasengan"
                        });
                });

            modelBuilder.Entity("rpg_training.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("HashedPassword")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("SaltPassword")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("rpg_training.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique()
                        .HasFilter("[CharacterId] IS NOT NULL");

                    b.ToTable("weapons");
                });

            modelBuilder.Entity("CharacterSkill", b =>
                {
                    b.HasOne("rpg_training.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("Charactersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rpg_training.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("rpg_training.Models.Character", b =>
                {
                    b.HasOne("rpg_training.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("rpg_training.Models.Weapon", b =>
                {
                    b.HasOne("rpg_training.Models.Character", "Character")
                        .WithOne("Weapon")
                        .HasForeignKey("rpg_training.Models.Weapon", "CharacterId");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("rpg_training.Models.Character", b =>
                {
                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("rpg_training.Models.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
