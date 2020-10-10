using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.MedicationDistributions
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;

        public DeleteModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MedicationDistribution MedicationDistribution { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicationDistribution = await _context.MedicationDistributions.FirstOrDefaultAsync(m => m.ID == id);

            if (MedicationDistribution == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicationDistribution = await _context.MedicationDistributions.FindAsync(id);

            if (MedicationDistribution != null)
            {
                _context.MedicationDistributions.Remove(MedicationDistribution);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
