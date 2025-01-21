namespace patitu_florin_proiect.Modele
{
    public class Vehicul
    {
        public int VehiculID { get; set; }
        public required string NumarInmatriculare { get; set; }
        public required string Model { get; set; }
        public required string Marca { get; set; }
        public ICollection<SarcinaService> SarciniService { get; set; }
    }
}
