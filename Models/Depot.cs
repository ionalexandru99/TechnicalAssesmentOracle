using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalAssesmentOracle.Models
{
    public class Depot
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        public ICollection<MedicationUnit> MedicationUnits { get; set; }
    }
}
