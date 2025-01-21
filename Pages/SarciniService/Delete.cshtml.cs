using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using patitu_florin_proiect.Modele;

namespace patitu_florin_proiect.Pages.SarciniService
{
    public class DeleteModel : PageModel
    {
        private readonly patitu_florin_proiect.Modele.DataContext _context;

        public DeleteModel(patitu_florin_proiect.Modele.DataContext context)
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

            var sarcinaservice = await _context.SarciniService.FirstOrDefaultAsync(m => m.SarcinaServiceID == id);

            if (sarcinaservice == null)
            {
                return NotFound();
            }
            else
            {
                SarcinaService = sarcinaservice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sarcinaservice = await _context.SarciniService.FindAsync(id);
            if (sarcinaservice != null)
            {
                SarcinaService = sarcinaservice;
                _context.SarciniService.Remove(SarcinaService);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
