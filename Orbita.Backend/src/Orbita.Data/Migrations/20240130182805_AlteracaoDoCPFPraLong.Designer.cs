﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orbita.Data;

#nullable disable

namespace Orbita.Data.Migrations
{
    [DbContext(typeof(OrbitaDbContext))]
    [Migration("20240130182805_AlteracaoDoCPFPraLong")]
    partial class AlteracaoDoCPFPraLong
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Orbita.Model.Student", b =>
                {
                    b.Property<int>("RA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("CPF")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RA");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
