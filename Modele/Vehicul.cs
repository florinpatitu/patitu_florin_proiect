using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace patitu_florin_proiect.Modele
{
    public class Vehicul
    {
        public int VehiculID { get; set; }

        [Required(ErrorMessage = "Numarul de inmatriculare este obligatoriu.")]
        public string? NumarInmatriculare { get; set; } = string.Empty;

        [Required(ErrorMessage = "Modelul este obligatoriu.")]
        public string? Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "Marca este obligatorie.")]
        public string? Marca { get; set; } = string.Empty;

        public ICollection<SarcinaService> SarciniService { get; set; } = new List<SarcinaService>();
    }
}
