using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Data
{
    public class TechnicalAssesmentOracleContext : DbContext
    {
        public TechnicalAssesmentOracleContext(DbContextOptions<TechnicalAssesmentOracleContext> options)
            : base(options)
        {
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationDistribution> MedicationDistributions { get; set; }
        public DbSet<MedicationUnit> MedicationUnits { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectBuy> SubjectBuys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().ToTable("Site");
            modelBuilder.Entity<Depot>().ToTable("Depot");
            modelBuilder.Entity<Medication>().ToTable("Medication");
            modelBuilder.Entity<MedicationUnit>().ToTable("MedicationUnit");
            modelBuilder.Entity<MedicationDistribution>().ToTable("MedicationDistribution");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<SubjectBuy>().ToTable("SubjectBuy");
        }
    }
}
