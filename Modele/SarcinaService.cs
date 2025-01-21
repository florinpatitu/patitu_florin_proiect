namespace patitu_florin_proiect.Modele
{
    public class SarcinaService
    {
        public int SarcinaServiceID { get; set; }
        public string Descriere { get; set; }
        public DateTime DataProgramare { get; set; }
        public int VehiculID { get; set; }
        public Vehicul Vehicul { get; set; }
        public int MecanicID { get; set; }
        public Mecanic Mecanic { get; set; }
    }
}
