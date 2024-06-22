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
    public class OrderController : ControllerBase
    {
        IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet(Name = "GetOrders")]
        public IActionResult GetOrders()
        {
           return Ok(_service.GetOrders());
        }

        [HttpPost(Name = "AddOrder")]
        public IActionResult AddOrder([FromBody] AddOrderDTO addOrder)
        {      
            return Ok(_service.AddOrder(addOrder));
        }
    }
}
