using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Services.Interfaces
{
    public interface IEventoService
    {
       Task<Evento> AddEventos (Evento model);
       Task<Evento> UpdateEventos (int Id, Evento model);
       Task<bool> Delete (int Id);

        Task<ICollection<Evento>> GetAllEventosAsync(bool includingPalestrantes = false);        
        Task<ICollection<Evento>> GetAllEventosByTemaAsync(string tema, bool includingPalestrantes = false);
        Task<Evento> GetEventosByIdAsync(int Id, bool includingPalestrantes = false);
    }
}