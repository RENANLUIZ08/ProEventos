using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Repository.Context;
using ProEventos.Repository.Repositories.Interfaces;

namespace ProEventos.Repository.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ProEventosContext _context;
        public EventoRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Evento>> GetAllEventosAsync(bool includingPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lote)
            .Include(e => e.RedesSociais);

            if (includingPalestrantes)
            { query = query.Include(e => e.Palestrantes); }

            query = query.OrderBy(e => e.Id);

            return await query.ToListAsync();
        }

        public async Task<ICollection<Evento>> GetAllEventosByTemaAsync(string tema, bool includingPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lote)
            .Include(e => e.RedesSociais);

            if (includingPalestrantes)
            { query = query.Include(e => e.Palestrantes); }

            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToListAsync();
        }
        public async Task<Evento> GetEventosByIdAsync(int Id, bool includingPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lote)
            .Include(e => e.RedesSociais);

            if (includingPalestrantes)
            { query = query.Include(e => e.Palestrantes); }

            query = query.OrderBy(e => e.Id).Where(e => e.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

    }
}