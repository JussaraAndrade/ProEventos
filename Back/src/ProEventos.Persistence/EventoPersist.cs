using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;

        public EventoPersist(ProEventosContext context)
        {
            _context = context;
            // essa linha informa que não quer segurar 
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes) {
                query = query
                    // A cada eventos que tiver. PalestrantesEventos, então ...
                    .Include(e => e.PalestrantesEventos)
                    // Inclua os palestrantes
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);
            
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes) {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }
            /*
                Where(e => e.Tema); a cada eventos que tiver procura o tema converte para LowerCase e analiar se ele contém
                um tema que está passado no parâmetro de entrada
            */                                                 
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes) {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Id == eventoId);
            
            return await query.FirstOrDefaultAsync();
        }
    }
}