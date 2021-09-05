using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        public Evento[] _evento = new Evento[]{
                new Evento()
                {
                    EventoId = 1,
                    Tema = "Angular 11 e Dotnet 5",
                    Local = "Presidente Prudente",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImagemURL = "foto.jpeg"
                },
                new Evento()
                {
                    EventoId = 1,
                    Tema = "Angular 11 e Dotnet 5",
                    Local = "São Paulo",
                    Lote = "2º Lote",
                    QtdPessoas = 350,
                    DataEvento = DateTime.Now.AddMonths(2).ToString("dd/MM/yyyy"),
                    ImagemURL = "foto.jpeg"
                }
            };
        private readonly DataContext _context;
        public EventosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{Id}")]
        public Evento GetById(int Id)
        {
            return _context.Eventos.FirstOrDefault(c => c.EventoId == Id);
        }
    }
}
