using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventosWeb.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventosWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private IEnumerable<Evento> _evento = new Evento[] {
                new Evento() {
                    EventoId = 1,
                    Tema = "Angular 11 e .NET5",
                    Local = "Belo Horizonte",
                    Lote = "1º Lote",
                    QuantidadePessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyy"),
                    ImagemURL = "foto.png"
                },
                new Evento() {
                    EventoId = 2,
                    Tema = "Angular 14 e .NET6",
                    Local = "São Paulo",
                    Lote = "2º Lote",
                    QuantidadePessoas = 350,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyy"),
                    ImagemURL = "foto2.png"
                }
            };

        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }
    }
}
