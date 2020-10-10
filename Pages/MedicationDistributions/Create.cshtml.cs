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

namespace TechnicalAssesmentOracle.Pages.MedicationDistributions
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
            Medications = await _context.Medications.ToListAsync();
            Subjects = await _context.Subjects.ToListAsync();

            return Page();
        }

        [BindProperty]
        public MedicationDistribution MedicationDistribution { get; set; }
        public IList<Medication> Medications { get; set; }
        public IList<Subject> Subjects { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MedicationDistributions.Add(MedicationDistribution);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
