using DataEntity.Data;
using DataEntity.Data.Enum;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataEntity
{
    // Classu pojmenovat : DbContext - Dědí z Microsoft.EntityFrameworkCore.DbContext
    public class SkladContext : DbContext
    {
        public DbSet<Material> Material => Set<Material>();
        public DbSet<MernaJednotka> MernaJednotka => Set<MernaJednotka>();
        public DbSet<Paleta> Paleta => Set<Paleta>();

        public MernaJednotka mjKs { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseSqlServer(
                        "Data Source=(localdb)\\MSSQLLocalDB;" +
                        "Database=SkladCv2_2026;" +
                        "Integrated Security=True;" +
                        "TrustServerCertificate=True;")
                    .UseLazyLoadingProxies();
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Material>().HasData(
                new
                {
                    MaterialId = 1,
                    Nazev = "Vrut 6",
                    MnozPoj = 0,
                    MnozDoPal = 0,
                    Datum = new DateTime(2026, 1, 1),
                    Komentar = "Komentar k Vrutu 6",
                    MernaJednotkaId = 1
                });

            modelBuilder.Entity<MernaJednotka>().HasData(
                new MernaJednotka { MernaJednotkaId = 1, Popis = "ks" },
                new MernaJednotka { MernaJednotkaId = 2, Popis = "kg" },
                new MernaJednotka { MernaJednotkaId = 3, Popis = "m3" });

            var materialSroub = new Material
            {
                Nazev = "Šroub",
                MnozPoj = 1000,
                MnozDoPal = 2000,
                Datum = DateTime.Now,
                MernaJednotka = mjKs
            };

            var materialHrebik = new Material
            {
                Nazev = "Hřebík",
                MnozPoj = 1500,
                MnozDoPal = 1000,
                Datum = DateTime.Now,
                MernaJednotka = mjKs
            };
            var palety = new[]
           {
                new Paleta
                {
                    Stav = Enums.PaletaStav.Vyskladneno,
                    Typ = Enums.PaletaTyp.Velka,
                    Material = materialSroub,
                    AdresaUlozeni = "M10",
                    Mnozstvi = 500
                },
                new Paleta
                {
                    Stav = Enums.PaletaStav.Vyskladneno,
                    Typ = Enums.PaletaTyp.Velka,
                    Material = materialSroub,
                    AdresaUlozeni = "M2",
                    Mnozstvi = 750
                },
                new Paleta
                {
                    Stav = Enums.PaletaStav.Vyskladneno,
                    Typ = Enums.PaletaTyp.Velka,
                    Material = materialHrebik,
                    AdresaUlozeni = "M2/5",
                    Mnozstvi = 1000
                }
            };
        }
    }
}

