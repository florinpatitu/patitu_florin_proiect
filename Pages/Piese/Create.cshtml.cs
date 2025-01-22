using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using patitu_florin_proiect.Modele;
using System.Threading.Tasks;

namespace patitu_florin_proiect.Pages.Piese
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Piesa Piesa { get; set; } = new Piesa();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Piese.Add(Piesa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
