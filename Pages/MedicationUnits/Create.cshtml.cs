using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.MedicationUnits
{
    public class CreateModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;

        public CreateModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Sites = await _context.Sites.ToListAsync();
            Depots = await _context.Depots.ToListAsync();
            Medications = await _context.Medications.ToListAsync();
            return Page();
        }

        [BindProperty]
        public MedicationUnit MedicationUnit { get; set; }
        public IList<Site> Sites { get; set; }
        public IList<Medication> Medications { get; set; }
        public IList<Depot> Depots { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MedicationUnits.Add(MedicationUnit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
