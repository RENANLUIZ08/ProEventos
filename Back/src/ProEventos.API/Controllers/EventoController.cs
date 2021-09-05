using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
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
        public EventoController(ILogger<EventoController> logger)
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{Id}")]
        public IEnumerable<Evento> GetById(int Id)
        {
            return _evento.Where(c => c.EventoId == Id);
        }
    }
}
