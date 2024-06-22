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
            return Ok(_service.GetTransports());
        }

        [HttpPost(Name = "AddTransport")]
        public IActionResult AddTransport([FromBody] AddTransportDTO transportDTO)
        { 
            return Ok();
        }
    }
}
