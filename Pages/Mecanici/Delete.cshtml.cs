using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using patitu_florin_proiect.Modele;

namespace patitu_florin_proiect.Pages.Mecanici
{
    public class DeleteModel : PageModel
    {
        private readonly patitu_florin_proiect.Modele.DataContext _context;

        public DeleteModel(patitu_florin_proiect.Modele.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mecanic Mecanic { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Mecanic = await _context.Mecanici.FirstOrDefaultAsync(m => m.MecanicID == id);

            if (Mecanic == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Mecanic == null)
            {
                return NotFound();
            }

            _context.Mecanici.Remove(Mecanic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
