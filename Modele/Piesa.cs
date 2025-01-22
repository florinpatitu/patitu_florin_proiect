using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace patitu_florin_proiect.Modele
{
    public class Piesa
    {
        public int PiesaID { get; set; }

        [Required(ErrorMessage = "Numele piesei este obligatoriu.")]
        public string? Nume { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Pretul trebuie ss fie mai mare de 0.")]
        public decimal Pret { get; set; }

        [ValidateNever]
        public ICollection<SarcinaService>? SarciniService { get; set; }
    }
}
