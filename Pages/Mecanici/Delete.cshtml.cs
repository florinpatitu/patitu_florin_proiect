using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using patitu_florin_proiect.Modele;
using System.Threading.Tasks;

namespace patitu_florin_proiect.Pages.Mecanici
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _context;

        public DeleteModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mecanic? Mecanic { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Mecanic = await _context.Mecanici.FindAsync(id);

            if (Mecanic == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var mecanicToDelete = await _context.Mecanici.FindAsync(id);

            if (mecanicToDelete == null)
            {
                return NotFound();
            }

            _context.Mecanici.Remove(mecanicToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
