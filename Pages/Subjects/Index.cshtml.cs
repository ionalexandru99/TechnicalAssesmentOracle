using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;
        public IList<MedicationDistribution> MedicationDistributions { get; set; }
        public IndexModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; }

        public async Task OnGetAsync()
        {
            Subject = await _context.Subjects.ToListAsync();
            MedicationDistributions = await _context.MedicationDistributions.ToListAsync();
        }

        public string Medications(int id)
        {
            string result = String.Empty;

            var distributions = MedicationDistributions.Where(x => x.SubjectId == id).ToList();
            var medications = distributions.Select(x => x.MedicationId);

            result = String.Join(", ", medications);

            return result;
        }
    }
}
