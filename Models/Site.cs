using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalAssesmentOracle.Models
{
    public class Site
    {
        [Required]
        [Range(10000, 99999, ErrorMessage = "The Id must have 5 digits")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [StringLength(250)]
        public string Doctor { get; set; }

        [Required]
        public bool Active { get; set; }

        public ICollection<MedicationUnit> MedicationUnits { get; set; }
    }
}
