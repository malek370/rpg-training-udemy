﻿// <auto-generated />
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
    [Migration("20231022192500_seedDb")]
    partial class seedDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.HasKey("id");

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
                            Strength = 10
                        },
                        new
                        {
                            id = 2,
                            Class = 1,
                            Defense = 10,
                            Hitpoints = 100,
                            Intelligence = 10,
                            Name = "chaima",
                            Strength = 10
                        },
                        new
                        {
                            id = 3,
                            Class = 3,
                            Defense = 10,
                            Hitpoints = 100,
                            Intelligence = 10,
                            Name = "Mariem",
                            Strength = 10
                        });
                });
#pragma warning restore 612, 618
        }
    }
}