using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.Sites
{
    public class IndexModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;
        public IList<MedicationUnit> MedicationUnits { get; set; }

        public IndexModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
        }

        public IList<Site> Site { get;set; }

        public async Task OnGetAsync()
        {
            Site = await _context.Sites.ToListAsync();
            MedicationUnits = await _context.MedicationUnits.ToListAsync();
        }

        public string Medications(int id)
        {
            string result = String.Empty;

            var units = MedicationUnits.Where(x => x.SiteId == id).ToList();
            var medications = units.Select(x => x.MedicationId);

            result = String.Join(", ", medications);

            return result;
        }
    }
}
