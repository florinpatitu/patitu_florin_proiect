using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using patitu_florin_proiect.Modele;
using System.Threading.Tasks;

namespace patitu_florin_proiect.Pages.Mecanici
{
    public class EditModel : PageModel
    {
        private readonly DataContext _context;

        public EditModel(DataContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mecanicToUpdate = await _context.Mecanici.FindAsync(Mecanic?.MecanicID);

            if (mecanicToUpdate == null)
            {
                return NotFound();
            }

            mecanicToUpdate.Nume = Mecanic.Nume;
            mecanicToUpdate.Prenume = Mecanic.Prenume;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
