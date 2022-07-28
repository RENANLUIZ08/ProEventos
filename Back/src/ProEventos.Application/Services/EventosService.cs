using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Application.Services.Interfaces;
using ProEventos.Domain;
using ProEventos.Repository.Repositories.Interfaces;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IRepository _repository;
        private readonly IEventoRepository _eventoRepository;
        public EventoService(IRepository repository, IEventoRepository eventoRepository)
        {
            _repository = repository;
            _eventoRepository = eventoRepository;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _repository.Add<Evento>(model);
                if (await _repository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao salvar. Detalhes: {ex.Message}.");
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var evento = await _eventoRepository.GetEventosByIdAsync(Id, false);

                if (evento == null)
                { throw new Exception("O Evento não foi encontrado."); }

                _repository.Delete<Evento>(evento);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao deletar. Detalhes: {ex.Message}.");
            }
        }

        public async Task<Evento> UpdateEventos(int Id, Evento model)
        {
            try
            {
                var evento = await _eventoRepository.GetEventosByIdAsync(Id, false);

                if (evento == null)
                { return null; }

                model.Id = evento.Id;
                if (await _repository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao atualizar. Detalhes: {ex.Message}.");
            }
        }
        public async Task<ICollection<Evento>> GetAllEventosAsync(bool includingPalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosAsync(includingPalestrantes);
                if (eventos.Count == 0) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Evento>> GetAllEventosByTemaAsync(string tema, bool includingPalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, includingPalestrantes);
                if (eventos.Count == 0) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventosByIdAsync(int Id, bool includingPalestrantes = false)
        {
            try
            {
                var evento = await _eventoRepository.GetEventosByIdAsync(Id, includingPalestrantes);
                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}