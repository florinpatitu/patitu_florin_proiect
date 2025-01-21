using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using patitu_florin_proiect.Modele;

namespace patitu_florin_proiect.Pages.Vehicule
{
    public class DetailsModel : PageModel
    {
        private readonly patitu_florin_proiect.Modele.DataContext _context;

        public DetailsModel(patitu_florin_proiect.Modele.DataContext context)
        {
            _context = context;
        }

        public Vehicul Vehicul { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicul = await _context.Vehicule.FirstOrDefaultAsync(m => m.VehiculID == id);
            if (vehicul == null)
            {
                return NotFound();
            }
            else
            {
                Vehicul = vehicul;
            }
            return Page();
        }
    }
}
