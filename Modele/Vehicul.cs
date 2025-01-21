namespace patitu_florin_proiect.Modele
{
    public class Vehicul
    {
        public int VehiculID { get; set; }
        public string NumarInmatriculare { get; set; }
        public string Model { get; set; }
        public string Marca { get; set; }
        public ICollection<SarcinaService> SarciniService { get; set; }
    }
}
