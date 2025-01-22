using System.ComponentModel.DataAnnotations;

namespace patitu_florin_proiect.Modele
{
    public class SarcinaService
    {
        public int SarcinaServiceID { get; set; }

        [Required(ErrorMessage = "Descrierea este obligatorie.")]
        public string Descriere { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data programarii este obligatorie.")]
        public DateTime DataProgramare { get; set; }

        public int VehiculID { get; set; }
        public Vehicul Vehicul { get; set; } = new Vehicul();

        public int MecanicID { get; set; }
        public Mecanic Mecanic { get; set; } = new Mecanic();

        public int? PiesaID { get; set; }
        public Piesa? Piesa { get; set; }
    }
}
