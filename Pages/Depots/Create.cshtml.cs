using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.Depots
{
    public class CreateModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;

        public CreateModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Depot Depot { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Depots.Add(Depot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
