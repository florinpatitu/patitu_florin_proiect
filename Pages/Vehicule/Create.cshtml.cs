﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using patitu_florin_proiect.Modele;

namespace patitu_florin_proiect.Pages.Vehicule
{
    public class CreateModel : PageModel
    {
        private readonly patitu_florin_proiect.Modele.DataContext _context;

        public CreateModel(patitu_florin_proiect.Modele.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vehicul Vehicul { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vehicule.Add(Vehicul);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
