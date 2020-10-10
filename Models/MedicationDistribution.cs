using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalAssesmentOracle.Models
{
    public class MedicationDistribution
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int ID { get; set; }
        [Required]
        [ForeignKey("Subject")]
        [DisplayName("Subject Id")]
        public int SubjectId { get; set; }
        [Required]
        [ForeignKey("Medication")]
        [DisplayName("Medication Id")]
        public int MedicationId { get; set; }
    }
}
