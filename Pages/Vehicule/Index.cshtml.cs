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
    public class IndexModel : PageModel
    {
        private readonly patitu_florin_proiect.Modele.DataContext _context;

        public IndexModel(patitu_florin_proiect.Modele.DataContext context)
        {
            _context = context;
        }

        public IList<Vehicul> Vehicul { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Vehicul = await _context.Vehicule.ToListAsync();
        }
    }
}
