using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using patitu_florin_proiect.Modele;

namespace patitu_florin_proiect.Pages.Piese
{
    public class EditModel : PageModel
    {
        private readonly patitu_florin_proiect.Modele.DataContext _context;

        public EditModel(patitu_florin_proiect.Modele.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Piesa Piesa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piesa =  await _context.Piese.FirstOrDefaultAsync(m => m.PiesaID == id);
            if (piesa == null)
            {
                return NotFound();
            }
            Piesa = piesa;
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

            _context.Attach(Piesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiesaExists(Piesa.PiesaID))
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

        private bool PiesaExists(int id)
        {
            return _context.Piese.Any(e => e.PiesaID == id);
        }
    }
}
