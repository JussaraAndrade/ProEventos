using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) 
            : base (options){ } // Construtor
        public DbSet<Evento> Eventos { get; set; } // Mapeamento de uma classe do banco de dados
        public DbSet<Lote> Lotes { get; set; } 
        public DbSet<Palestrante> Palestrantes { get; set; } 
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; } 
        public DbSet<RedeSocial> RedesSociais { get; set; }

        // Muitos pra muitos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tem uma Entidade do tipo PalestranteEvento
            // Nesse código faz associação de Eventos e Palestrante, quando faz a criação no BD os Id é inserido
            modelBuilder.Entity<PalestranteEvento>()
                /* HaskKey; tem chaves dado um PalestranteEvento, quero que toda vez que busca dado 
                    PalestranteEvento, fala que PE do PalestranteEvento EventoId está para PalestranteId
                */
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>()
                    .HasMany(e => e.RedesSociais) // Que possui Rede Social
                    .WithOne(rs => rs.Evento) // Deletou o Evento 
                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                    .HasMany(e => e.RedesSocais) // Por favpr deleta as redes sociais
                    .WithOne(rs => rs.Palestrante) // Se achar um palestrante
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}