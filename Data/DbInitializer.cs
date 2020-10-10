using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Data
{
    public class DbInitializer
    {
        public static void Initialize(TechnicalAssesmentOracleContext context)
        {
            context.Database.EnsureCreated();

            if (context.MedicationUnits.Any())
            {
                return;
            }

            var sites = new Site[]
            {
                new Site
                {
                    ID = 10001,
                    Address = "Bulevardul Corneliu Coposu 2-4, 550245, Sibiu",
                    Doctor = "Daniela  Georgescu",
                    Active = true
                },
                new Site
                {
                    ID = 10002,
                    Address = "BD. TOMIS nr. 80, CONSTANŢA, 900657",
                    Doctor = "Sofia Lucescu",
                    Active = true
                },
                new Site
                {
                    ID = 10003,
                    Address = "Strada Capitan Eremia Popescu 21, Bucuresti",
                    Doctor = "Octavian  Prunea",
                    Active = true
                }
            };

            context.Sites.AddRange(sites);
            context.SaveChanges();

            var depots = new Depot[]
            {
                new Depot
                {
                    Address = "STR. FABRICII nr. 124, CLUJ, 400640"
                },
                new Depot
                {
                    Address = "Strada Stefan Augustin Doinas 32, Arad"
                }
            };

            context.Depots.AddRange(depots);
            context.SaveChanges();

            var subjects = new Subject[]
            {
                new Subject
                {
                    Name = "Denisa Preda",
                    Gender = Gender.Female,
                    BirthDate = DateTime.Parse("3/29/1995"),
                    SiteId = 10001
                },
                new Subject
                {
                    Name = "Razvan Ilie",
                    Gender = Gender.Male,
                    BirthDate = DateTime.Parse("3/26/1982"),
                    SiteId = 10001
                },
                new Subject
                {
                    Name = "Ciprian Pangratiu",
                    Gender = Gender.Male,
                    BirthDate = DateTime.Parse("3/8/1979"),
                    SiteId = 10001
                },
                new Subject
                {
                    Name = "Catalena Nechita",
                    Gender = Gender.Female,
                    BirthDate = DateTime.Parse("7/13/1996"),
                    SiteId = 10002
                },
                new Subject
                {
                    Name = "Constantin Baicu",
                    Gender = Gender.Male,
                    BirthDate = DateTime.Parse("8/31/1989"),
                    SiteId = 10002
                },
                new Subject
                {
                    Name = "Doina Caragiale",
                    Gender = Gender.Female,
                    BirthDate = DateTime.Parse("10/24/1977"),
                    SiteId = 10003
                }
            };

            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            var medications = new Medication[]
            {
                new Medication
                {
                    ID = 233690,
                    Name = "Acetaminophen"
                },
                new Medication
                {
                    ID = 233691,
                    Name = "Amitriptyline"
                },
                new Medication
                {
                    ID = 233692,
                    Name = "Methadone"
                }
            };

            context.Medications.AddRange(medications);
            context.SaveChanges();

            var medicationUnits = new MedicationUnit[]
            {
                new MedicationUnit
                {
                    SiteId = 10001,
                    DepotId = 1,
                    MedicationId = 233690,
                    Quantity = 100
                },
                new MedicationUnit
                {
                    SiteId = 10001,
                    DepotId = 2,
                    MedicationId = 233690,
                    Quantity = 50,
                },
                new MedicationUnit
                {
                    SiteId = 10001,
                    DepotId = 1,
                    MedicationId = 233691,
                    Quantity = 25
                },
                new MedicationUnit
                {
                    SiteId = 10001,
                    DepotId = 2, 
                    MedicationId = 233691,
                    Quantity = 150,
                },
                new MedicationUnit
                {
                    SiteId = 10001,
                    DepotId = 1,
                    MedicationId = 233692,
                    Quantity = 300
                },
                new MedicationUnit
                {
                    SiteId = 10002,
                    DepotId = 1,
                    MedicationId = 233690,
                    Quantity = 55
                },
                new MedicationUnit
                {
                    SiteId = 10002,
                    DepotId = 2,
                    MedicationId = 233691,
                    Quantity = 100
                },
                new MedicationUnit
                {
                    SiteId = 10003,
                    DepotId = 1,
                    MedicationId = 233692,
                    Quantity = 200
                }
            };

            context.MedicationUnits.AddRange(medicationUnits);
            context.SaveChanges();

            var medicationDistributions = new MedicationDistribution[]
            {
                new MedicationDistribution
                {
                    SubjectId = 1000,
                    MedicationId = 233690
                },
                new MedicationDistribution
                {
                    SubjectId = 1000,
                    MedicationId = 233691
                },
                new MedicationDistribution
                {
                    SubjectId = 1001,
                    MedicationId = 233692
                },
                new MedicationDistribution
                {
                    SubjectId = 1001,
                    MedicationId = 233690
                },
                new MedicationDistribution
                {
                    SubjectId = 1002,
                    MedicationId = 233690,
                },
                new MedicationDistribution
                {
                    SubjectId = 1002,
                    MedicationId = 233691,
                },
                new MedicationDistribution
                {
                    SubjectId = 1002,
                    MedicationId = 233692,
                },new MedicationDistribution
                {
                    SubjectId = 1003,
                    MedicationId = 233691,
                },
                new MedicationDistribution
                {
                    SubjectId = 1004,
                    MedicationId = 233690,
                },
                new MedicationDistribution
                {
                    SubjectId = 1005,
                    MedicationId = 233691,
                },
                new MedicationDistribution
                {
                    SubjectId = 1005,
                    MedicationId = 233692,
                }
            };

            context.MedicationDistributions.AddRange(medicationDistributions);
            context.SaveChanges();
        }

    }
}
