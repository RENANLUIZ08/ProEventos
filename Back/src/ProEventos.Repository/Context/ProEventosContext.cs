using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Repository.Context
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options)
         : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Palestrante>().HasMany(p => p.Eventos).WithMany(e => e.Palestrantes);
        }
    }
}