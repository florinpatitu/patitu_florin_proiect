using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using patitu_florin_proiect.Modele;

namespace patitu_florin_proiect.Pages.Piese
{
    public class DeleteModel : PageModel
    {
        private readonly patitu_florin_proiect.Modele.DataContext _context;

        public DeleteModel(patitu_florin_proiect.Modele.DataContext context)
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

            var piesa = await _context.Piese.FirstOrDefaultAsync(m => m.PiesaID == id);

            if (piesa == null)
            {
                return NotFound();
            }
            else
            {
                Piesa = piesa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piesa = await _context.Piese.FindAsync(id);
            if (piesa != null)
            {
                Piesa = piesa;
                _context.Piese.Remove(Piesa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
