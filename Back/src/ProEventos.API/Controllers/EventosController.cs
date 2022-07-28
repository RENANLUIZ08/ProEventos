using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Repository.Context;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ProEventosContext _context;
        public EventosController(ProEventosContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]
        public Evento GetById(int Id)
        {
            return _context.Eventos.FirstOrDefault(c => c.Id == Id);
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }
    }
}
