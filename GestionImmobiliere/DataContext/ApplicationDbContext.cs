using System.Data.Entity;
using GestionImmobiliere.Models;

namespace GestionImmobiliere.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() :base(nameOrConnectionString:"MyConnection")
        {

        }
        public virtual DbSet<Owner> Owners { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public System.Data.Entity.DbSet<GestionImmobiliere.Models.Logement> Logements { get; set; }

        public System.Data.Entity.DbSet<GestionImmobiliere.Models.Rental_File> Rental_File { get; set; }

        public System.Data.Entity.DbSet<GestionImmobiliere.Models.Rental_Payment> Rental_Payment { get; set; }

          }
}