using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using patitu_florin_proiect.Modele;
using System.Threading.Tasks;

namespace patitu_florin_proiect.Pages.Mecanici
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mecanic Mecanic { get; set; } = new Mecanic();

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

            _context.Mecanici.Add(Mecanic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
