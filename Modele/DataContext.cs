using Microsoft.EntityFrameworkCore;

namespace patitu_florin_proiect.Modele
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Console.WriteLine("Database connection initialized.");
        }

        public DbSet<Vehicul> Vehicule { get; set; }
        public DbSet<Mecanic> Mecanici { get; set; }
        public DbSet<SarcinaService> SarciniService { get; set; }
        public DbSet<Piesa> Piese { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  relatie Vehicul - SarcinaService
            modelBuilder.Entity<Vehicul>()
                .HasMany(v => v.SarciniService)
                .WithOne(s => s.Vehicul)
                .HasForeignKey(s => s.VehiculID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurare relatie Mecanic - SarcinaService
            modelBuilder.Entity<Mecanic>()
                .HasMany(m => m.SarciniService)
                .WithOne(s => s.Mecanic)
                .HasForeignKey(s => s.MecanicID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurare relatie Piesa - SarcinaService
            modelBuilder.Entity<SarcinaService>()
                .HasOne(s => s.Piesa)
                .WithMany(p => p.SarciniService)
                .HasForeignKey(s => s.PiesaID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurare coloana Pret pentru Piesa
            modelBuilder.Entity<Piesa>()
                .Property(p => p.Pret)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
