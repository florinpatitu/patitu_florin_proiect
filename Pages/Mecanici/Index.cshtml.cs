using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using patitu_florin_proiect.Modele;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace patitu_florin_proiect.Pages.Mecanici
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IList<Mecanic> Mecanici { get; set; } = new List<Mecanic>();

        public async Task OnGetAsync()
        {
            Mecanici = await _context.Mecanici.ToListAsync();
        }
    }
}
