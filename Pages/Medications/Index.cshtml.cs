using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.Medications
{
    public class IndexModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;

        public IndexModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
        }

        public IList<Medication> Medication { get;set; }

        public async Task OnGetAsync()
        {
            Medication = await _context.Medications.ToListAsync();
        }
    }
}
