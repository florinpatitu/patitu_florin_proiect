using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using patitu_florin_proiect.Modele;

namespace patitu_florin_proiect.Pages.SarciniService
{
    public class EditModel : PageModel
    {
        private readonly patitu_florin_proiect.Modele.DataContext _context;

        public EditModel(patitu_florin_proiect.Modele.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SarcinaService SarcinaService { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sarcinaservice =  await _context.SarciniService.FirstOrDefaultAsync(m => m.SarcinaServiceID == id);
            if (sarcinaservice == null)
            {
                return NotFound();
            }
            SarcinaService = sarcinaservice;
           ViewData["MecanicID"] = new SelectList(_context.Mecanici, "MecanicID", "MecanicID");
           ViewData["VehiculID"] = new SelectList(_context.Vehicule, "VehiculID", "VehiculID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SarcinaService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SarcinaServiceExists(SarcinaService.SarcinaServiceID))
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

        private bool SarcinaServiceExists(int id)
        {
            return _context.SarciniService.Any(e => e.SarcinaServiceID == id);
        }
    }
}
