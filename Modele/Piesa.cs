namespace patitu_florin_proiect.Modele
{
    public class Piesa
    {
        public int PiesaID { get; set; }
        public string Nume { get; set; }
        public decimal Pret { get; set; }
        public ICollection<SarcinaService> SarciniService { get; set; }
    }
}
