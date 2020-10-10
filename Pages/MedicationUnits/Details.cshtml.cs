using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.MedicationUnits
{
    public class DetailsModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;

        public DetailsModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
        }

        public MedicationUnit MedicationUnit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicationUnit = await _context.MedicationUnits.FirstOrDefaultAsync(m => m.ID == id);

            if (MedicationUnit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
