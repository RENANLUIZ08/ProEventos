using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Services.Interfaces
{
    public interface IPalestranteService
    {
       Task<Palestrante> AddPalestrantes (Palestrante model);
       Task<Palestrante> UpdatePalestrantes (int Id, Palestrante model);
       Task<bool> Delete (int Id);

        Task<ICollection<Palestrante>> GetAllPalestrantesByNomeAsync(string nome, bool includingEventos = false);
        Task<ICollection<Palestrante>> GetAllPalestrantesAsync(bool includingEventos = false);
        Task<Palestrante> GetPalestrantesByIdAsync(int Id, bool includingEventos = false);
    }
}