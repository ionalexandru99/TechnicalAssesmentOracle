using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.Sites
{
    public class CreateModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;

        public string InvalidId { get; set; }
        public CreateModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Site Site { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var invalidId = await _context.Sites.Where(x => x.ID == Site.ID).ToListAsync();
            if(invalidId.Count != 0)
            {
                InvalidId = "The Id is already used!";
                return Page();
            }
            else
            {
                InvalidId = null;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sites.Add(Site);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
