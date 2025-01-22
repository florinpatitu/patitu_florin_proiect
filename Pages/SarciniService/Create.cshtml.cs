using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using patitu_florin_proiect.Modele;
using System.Threading.Tasks;

namespace patitu_florin_proiect.Pages.SarciniService
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SarcinaService SarcinaService { get; set; } = new SarcinaService();

        public IActionResult OnGet()
        {
            ViewData["VehiculID"] = new SelectList(_context.Vehicule, "VehiculID", "NumarInmatriculare");
            ViewData["MecanicID"] = new SelectList(_context.Mecanici, "MecanicID", "Nume");
            ViewData["PiesaID"] = new SelectList(_context.Piese, "PiesaID", "Nume");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["VehiculID"] = new SelectList(_context.Vehicule, "VehiculID", "NumarInmatriculare");
                ViewData["MecanicID"] = new SelectList(_context.Mecanici, "MecanicID", "Nume");
                ViewData["PiesaID"] = new SelectList(_context.Piese, "PiesaID", "Nume");
                return Page();
            }

            try
            {
                _context.SarciniService.Add(SarcinaService);
                await _context.SaveChangesAsync();
                Console.WriteLine("Sarcina adăugata cu succes.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la salvare: {ex.Message}");
                ModelState.AddModelError("", "A aparut o eroare la salvarea datelor.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
