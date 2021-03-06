﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicalAssesmentOracle.Data;

namespace TechnicalAssesmentOracle.Migrations
{
    [DbContext(typeof(TechnicalAssesmentOracleContext))]
    partial class TechnicalAssesmentOracleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.Depot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.ToTable("Depot");
                });

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.Medication", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Medication");
                });

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.MedicationDistribution", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedicationId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MedicationId");

                    b.ToTable("MedicationDistribution");
                });

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.MedicationUnit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepotId")
                        .HasColumnType("int");

                    b.Property<int>("MedicationId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DepotId");

                    b.HasIndex("MedicationId");

                    b.HasIndex("SiteId");

                    b.ToTable("MedicationUnit");
                });

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.Site", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Doctor")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.Subject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.SubjectBuy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("SubjectBuy");
                });

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.Medication", b =>
                {
                    b.HasOne("TechnicalAssesmentOracle.Models.Subject", null)
                        .WithMany("Medications")
                        .HasForeignKey("SubjectID");
                });

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.MedicationDistribution", b =>
                {
                    b.HasOne("TechnicalAssesmentOracle.Models.Medication", null)
                        .WithMany("MedicationDistributions")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechnicalAssesmentOracle.Models.MedicationUnit", b =>
                {
                    b.HasOne("TechnicalAssesmentOracle.Models.Depot", null)
                        .WithMany("MedicationUnits")
                        .HasForeignKey("DepotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalAssesmentOracle.Models.Medication", null)
                        .WithMany("MedicationUnits")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalAssesmentOracle.Models.Site", null)
                        .WithMany("MedicationUnits")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
