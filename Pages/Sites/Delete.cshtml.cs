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
    public class DeleteModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;
        public IList<MedicationUnit> MedicationUnits { get; set; }

        public DeleteModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Site Site { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MedicationUnits = await _context.MedicationUnits.ToListAsync();

            Site = await _context.Sites.FirstOrDefaultAsync(m => m.ID == id);

            if (Site == null)
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

            Site = await _context.Sites.FindAsync(id);

            if (Site != null)
            {
                _context.Sites.Remove(Site);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
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
