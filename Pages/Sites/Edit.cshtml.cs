﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.Sites
{
    public class EditModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;

        public EditModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
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

            Site = await _context.Sites.FirstOrDefaultAsync(m => m.ID == id);

            if (Site == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Site).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteExists(Site.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SiteExists(int id)
        {
            return _context.Sites.Any(e => e.ID == id);
        }
    }
}
