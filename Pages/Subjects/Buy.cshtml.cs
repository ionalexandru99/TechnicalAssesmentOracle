using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesmentOracle.Data;
using TechnicalAssesmentOracle.Models;

namespace TechnicalAssesmentOracle.Pages.Subjects
{
    public class BuyModel : PageModel
    {
        private readonly TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext _context;

        public BuyModel(TechnicalAssesmentOracle.Data.TechnicalAssesmentOracleContext context)
        {
            _context = context;
            Medications = new List<Medication>();
            MedicationUnits = new List<MedicationUnit>();
        }

        [BindProperty]
        public SubjectBuy SubjectBuy { get; set; }
        public Subject Subject { get; set; }
        public Medication Medication { get; set; }

        public IList<Medication> Medications { get; set; }
        public IList<MedicationUnit> MedicationUnits { get; set; }
        public string QuantityError;
        public string MedicationError;
        public string SiteInvalid;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subject = await _context.Subjects.FirstOrDefaultAsync(m => m.ID == id);
            var site = await _context.Sites.FirstOrDefaultAsync(s => s.ID == Subject.SiteId);

            if(!site.Active)
            {
                MedicationError = "The site associated to the subject is not active";
                return Page();
            }

            if (Subject == null)
            {
                return NotFound();
            }

            await GetMedications((int)id);

            if(Medications.Count == 0 || Medications == null)
            {
                MedicationError = "The subject does not have any medication asigned";
                return Page();
            }
           
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subject = await _context.Subjects.FirstOrDefaultAsync(m => m.ID == id);

            if (Subject == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            SubjectBuy.RequestDate = DateTime.Now.Date;

            await GetMedications((int)id);

            Medication = Medications.Where(x => x.Name.Trim().ToUpper().Equals(SubjectBuy.MedicationName.Trim().ToUpper())).First();
            var _medicationUnits = MedicationUnits.Where(x => x.MedicationId == Medication.ID).ToList();
            _medicationUnits = _medicationUnits.Where(x => x.SiteId == Subject.SiteId).ToList();

            int quantity = _medicationUnits.Sum(x => x.Quantity);

            if (quantity < SubjectBuy.Quantity)
            {
                QuantityError = "The specified quantity is not available!";
                return Page();
            }
            else
            {
                QuantityError = null;
            }

            quantity = SubjectBuy.Quantity;

            int counter = 0;
            while (quantity > 0)
            {
                if (quantity > _medicationUnits[counter].Quantity)
                {
                    quantity -= _medicationUnits[counter].Quantity;
                    _medicationUnits[counter].Quantity = 0;
                }
                else
                {
                    _medicationUnits[counter].Quantity -= quantity;
                    quantity = 0;
                }

                counter++;
            }

            foreach (var medicationUnit in _medicationUnits)
            {
                _context.Attach(medicationUnit).State = EntityState.Modified;
            }

            _context.SubjectBuys.Add(SubjectBuy);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(Subject.ID))
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

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.ID == id);
        }

        private async Task GetMedications(int id)
        {
            Medications = await _context.Medications.ToListAsync();
            var medicationDistributions = await _context.MedicationDistributions.ToListAsync();
            MedicationUnits = await _context.MedicationUnits.ToListAsync();

            var medicationIds = medicationDistributions.Where(x => x.SubjectId == id).Select(x => x.MedicationId).ToList();
            Medications = Medications.Where(x => medicationIds.Contains(x.ID)).ToList();
        }
    }
}
