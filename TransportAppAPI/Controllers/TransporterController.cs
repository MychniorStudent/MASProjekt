using Microsoft.AspNetCore.Mvc;
using TransportAppAPI.Contexts;
using TransportAppAPI.DTOs;
using TransportAppAPI.Enums;
using TransportAppAPI.Interfaces;
using TransportAppAPI.Models;

namespace TransportAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransporterController : ControllerBase
    {
        ITransportService _service;
        public TransporterController(ITransportService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetTransport")]
        public IActionResult GetTransport()
        {
            //SrodekTransportu srodekTransportu = new SrodekTransportu();
            //srodekTransportu.TerenTransportera = new List<TerenTransportera> { TerenTransportera.Ladowy, TerenTransportera.Wodny };
            //srodekTransportu.numerRejestracyjny = "AAA";
            //srodekTransportu.marka = "Wolkzwagen";
            //srodekTransportu.model = "Polo";
            //srodekTransportu.dataOstatniegoPrzeglady = DateTime.Now;
            //srodekTransportu.czyMozeNiebezpieczne = true;
            //srodekTransportu.MyProperty = 5;
            ////_context.SrodkiTransportu.Add(srodekTransportu);
            //_context.SaveChanges();

            //var heh2 = new SrodekTransportu
            //{
            //    TerenTransportera = new List<TerenTransportera> { TerenTransportera.Ladowy, TerenTransportera.Wodny },
            //    numerRejestracyjny = "WL1234",
            //    marka = "Wolkzwagen",
            //    model = "pu",
            //    dataOstatniegoPrzeglady = DateTime.Now,
            //    czyMozeNiebezpieczne = false,
            //    rodzajNapedu = RodzajNapedu.Spalinowy,
            //    iloscPaliwa = 50
            //};
            //var dane = _context.SrodkiTransportu.FirstOrDefault();
            //var heh = dane.MyProperty;
            return Ok(_service.GetTransports());
        }

        [HttpPost(Name = "AddTransport")]
        public IActionResult AddTransport([FromBody] AddTransportDTO transportDTO)
        { 
            return Ok();
        }
    }
}
