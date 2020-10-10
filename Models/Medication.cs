using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalAssesmentOracle.Models
{
    public class Medication
    {
        [Required]
        [Range(100000, 999999)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<MedicationDistribution> MedicationDistributions { get; set; }
        public ICollection<MedicationUnit> MedicationUnits { get; set; }
    }
}
