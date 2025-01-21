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
    public class EditModel : PageModel
    {
        private readonly patitu_florin_proiect.Modele.DataContext _context;

        public EditModel(patitu_florin_proiect.Modele.DataContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mecanic).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
