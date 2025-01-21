namespace patitu_florin_proiect.Modele
{
    public class Mecanic
    {
        public int MecanicID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public ICollection<SarcinaService> SarciniService { get; set; }
    }
}
