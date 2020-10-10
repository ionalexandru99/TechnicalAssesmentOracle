using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalAssesmentOracle.Models
{
    public class SubjectBuy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("Medication Name")]
        [Required]
        [StringLength(250)]
        public string MedicationName { get; set; }

        [Required]
        [Range(0,int.MaxValue, ErrorMessage = "The value can't be negative")]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Request Date")]
        public DateTime? RequestDate { get; set; }
    }
}
