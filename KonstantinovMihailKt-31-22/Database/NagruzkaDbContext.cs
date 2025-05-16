using KonstantinovMihailKt_31_22.Database.Configurations;
using KonstantinovMihailKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace KonstantinovMihailKt_31_22.Database
{
    public class NagruzkaDbContext : DbContext
    {
        DbSet<Nagruzka> Nagruzkas { get; set; }
        DbSet<Cafedra> Cafedras { get; set; }
        DbSet<Prepods> Prepods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CafedraConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplinesConfiguration());
            modelBuilder.ApplyConfiguration(new NagruzkaConfiguration());
            modelBuilder.ApplyConfiguration(new PositionsConfiguration());
            modelBuilder.ApplyConfiguration(new PrepodsConfiguration());
        }
        public NagruzkaDbContext(DbContextOptions<NagruzkaDbContext> options) : base(options) { }
    }
}
