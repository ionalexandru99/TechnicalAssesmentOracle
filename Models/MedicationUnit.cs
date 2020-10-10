using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalAssesmentOracle.Models
{
    public class MedicationUnit
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int ID { get; set; }
        [Required]
        [ForeignKey("Medication")]
        [DisplayName("Medication Id")]
        public int MedicationId { get; set; }
        [Required]
        [ForeignKey("Site")]
        [DisplayName("Site Id")]
        public int SiteId { get; set; }
        [Required]
        [ForeignKey("Depot")]
        [DisplayName("Depot Id")]
        public int DepotId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The quantity can't be negative")]
        public int Quantity { get; set; }
    }
}
