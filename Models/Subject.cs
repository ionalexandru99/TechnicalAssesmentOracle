using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalAssesmentOracle.Models
{
    public enum Gender
    {
        [Description("Male")]
        Male,
        [Description("Female")]
        Female
    }
    public class Subject
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DisplayName("Site Number")]
        public int SiteId { get; set; }

        public ICollection<Medication> Medications { get; set; }
    }
}
