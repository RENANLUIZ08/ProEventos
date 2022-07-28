using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Repository.Context;
using ProEventos.Repository.Repositories.Interfaces;

namespace ProEventos.Repository.Repositories
{
    public class PalestrantesRepository : IPalestranteRepository
    {
        private readonly ProEventosContext _context ;
        public PalestrantesRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Palestrante>> GetAllPalestrantesAsync(bool includingEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

            if(includingEventos) 
            {query = query.Include(p => p.Eventos);}

            query = query.OrderBy(p => p.Id);

            return await query.ToListAsync();
        }

        public async Task<ICollection<Palestrante>> GetAllPalestrantesByNomeAsync(string nome, bool includingEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

            if(includingEventos) 
            {query = query.Include(p => p.Eventos);}

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToListAsync();
        }

        public async Task<Palestrante> GetPalestrantesByIdAsync(int Id, bool includingEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

            if(includingEventos) 
            {query = query.Include(e => e.Eventos);}

            query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}