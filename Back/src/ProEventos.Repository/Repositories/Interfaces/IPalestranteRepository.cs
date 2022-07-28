using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Repository.Repositories.Interfaces
{
    public interface IPalestranteRepository
    {
       
       //palestrantes
        Task<ICollection<Palestrante>> GetAllPalestrantesByNomeAsync(string nome, bool includingEventos);
        Task<ICollection<Palestrante>> GetAllPalestrantesAsync(bool includingEventos);
        Task<Palestrante> GetPalestrantesByIdAsync(int Id, bool includingEventos);

    }
}