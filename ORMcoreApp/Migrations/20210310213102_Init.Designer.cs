﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORMcoreApp.DataAcces;

namespace ORMcoreApp.Migrations
{
    [DbContext(typeof(PoliceManContent))]
    [Migration("20210310213102_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ORMcoreApp.Models.Automobilis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarMake")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Passengers")
                        .HasColumnType("int");

                    b.Property<string>("VinId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("automobiliai");
                });

            modelBuilder.Entity("ORMcoreApp.Models.DienosAutomobilis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("automobilisId")
                        .HasColumnType("int");

                    b.Property<DateTime>("day")
                        .HasColumnType("datetime2");

                    b.Property<int?>("pareigunasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("automobilisId");

                    b.HasIndex("pareigunasId");

                    b.ToTable("skirtinguDienuAutomobiliai");
                });

            modelBuilder.Entity("ORMcoreApp.Models.Ginklas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GunID")
                        .HasColumnType("int");

                    b.Property<string>("GunModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GunName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pareigunasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("pareigunasId")
                        .IsUnique();

                    b.ToTable("ginklai");
                });

            modelBuilder.Entity("ORMcoreApp.Models.Pareigunas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("pareigunai");
                });

            modelBuilder.Entity("ORMcoreApp.Models.UzduociuListas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<DateTime>("day")
                        .HasColumnType("datetime2");

                    b.Property<int>("pareigunasId")
                        .HasColumnType("int");

                    b.Property<int?>("uzduotisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("pareigunasId")
                        .IsUnique();

                    b.HasIndex("uzduotisId");

                    b.ToTable("uzduociuListai");
                });

            modelBuilder.Entity("ORMcoreApp.Models.Uzduotis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Uzduotys");
                });

            modelBuilder.Entity("ORMcoreApp.Models.DienosAutomobilis", b =>
                {
                    b.HasOne("ORMcoreApp.Models.Automobilis", "automobilis")
                        .WithMany("SkirtinguDienuAutomobilis")
                        .HasForeignKey("automobilisId");

                    b.HasOne("ORMcoreApp.Models.Pareigunas", "pareigunas")
                        .WithMany("SkirtinguDienuAutomobilis")
                        .HasForeignKey("pareigunasId");

                    b.Navigation("automobilis");

                    b.Navigation("pareigunas");
                });

            modelBuilder.Entity("ORMcoreApp.Models.Ginklas", b =>
                {
                    b.HasOne("ORMcoreApp.Models.Pareigunas", "pareigunas")
                        .WithOne("ginklas")
                        .HasForeignKey("ORMcoreApp.Models.Ginklas", "pareigunasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pareigunas");
                });

            modelBuilder.Entity("ORMcoreApp.Models.UzduociuListas", b =>
                {
                    b.HasOne("ORMcoreApp.Models.Pareigunas", "pareigunas")
                        .WithOne("uzduociuListas")
                        .HasForeignKey("ORMcoreApp.Models.UzduociuListas", "pareigunasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORMcoreApp.Models.Uzduotis", "uzduotis")
                        .WithMany("Uzduotys")
                        .HasForeignKey("uzduotisId");

                    b.Navigation("pareigunas");

                    b.Navigation("uzduotis");
                });

            modelBuilder.Entity("ORMcoreApp.Models.Automobilis", b =>
                {
                    b.Navigation("SkirtinguDienuAutomobilis");
                });

            modelBuilder.Entity("ORMcoreApp.Models.Pareigunas", b =>
                {
                    b.Navigation("ginklas");

                    b.Navigation("SkirtinguDienuAutomobilis");

                    b.Navigation("uzduociuListas");
                });

            modelBuilder.Entity("ORMcoreApp.Models.Uzduotis", b =>
                {
                    b.Navigation("Uzduotys");
                });
#pragma warning restore 612, 618
        }
    }
}
