using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Repository.Repositories.Interfaces
{
    public interface IEventoRepository
    {

        //Eventos
        Task<ICollection<Evento>> GetAllEventosByTemaAsync(string tema, bool includingPalestrantes);
        Task<ICollection<Evento>> GetAllEventosAsync(bool includingPalestrantes);
        Task<Evento> GetEventosByIdAsync(int Id, bool includingPalestrantes);

    }
}