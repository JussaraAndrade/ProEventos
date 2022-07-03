using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){} // Construtor
        public DbSet<Evento> Eventos { get; set; } // Mapeamento de uma classe do banco de dados
    }
}