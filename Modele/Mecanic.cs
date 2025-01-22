using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace patitu_florin_proiect.Modele
{
    public class Mecanic
    {
        public int MecanicID { get; set; }

        [Required(ErrorMessage = "Numele mecanicului este obligatoriu.")]
        [StringLength(50, ErrorMessage = "Numele nu poate avea mai mult de 50 de caractere.")]
        public string Nume { get; set; } = string.Empty;

        [Required(ErrorMessage = "Prenumele mecanicului este obligatoriu.")]
        [StringLength(50, ErrorMessage = "Prenumele nu poate avea mai mult de 50 de caractere.")]
        public string Prenume { get; set; } = string.Empty;

        public ICollection<SarcinaService> SarciniService { get; set; } = new List<SarcinaService>();
    }
}
