﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToolMvc;

namespace ToolMvc.Migrations
{
    [DbContext(typeof(ToolMvcContext))]
    partial class ToolMvcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ToolMvc.Models.Place", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlaceAdress")
                        .IsRequired();

                    b.Property<string>("PlaceDescription")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("ToolMvc.Models.Tool", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("PlaceID");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("PlaceID");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("ToolMvc.Models.Tool", b =>
                {
                    b.HasOne("ToolMvc.Models.Place", "Place")
                        .WithMany("Tool")
                        .HasForeignKey("PlaceID");
                });
#pragma warning restore 612, 618
        }
    }
}
