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
            List<GetOrdersDTO> orders = new List<GetOrdersDTO>();
            orders.Add(new GetOrdersDTO { id = 1, nazwisko = "Kowalski", adres = "Warszawa", dataWyruszenia = DateTime.Now, status = "zrealizowana", planowanaDataDostarczenia = DateTime.Now.AddDays(5), dataDostarczenia = DateTime.Now.AddDays(10)});
            orders.Add(new GetOrdersDTO { id = 2, nazwisko = "Kowalski", adres = "Warszawa", dataWyruszenia = DateTime.Now, status = "nie", planowanaDataDostarczenia = DateTime.Now.AddDays(5), dataDostarczenia = DateTime.Now.AddDays(10)});
            orders.Add(new GetOrdersDTO { id = 3, nazwisko = "Kowalski", adres = "Warszawa", dataWyruszenia = DateTime.Now, status = "zrealizowana", planowanaDataDostarczenia = DateTime.Now.AddDays(5), dataDostarczenia = DateTime.Now.AddDays(10)});
            orders.Add(new GetOrdersDTO { id = 4, nazwisko = "Kowalski", adres = "Warszawa", dataWyruszenia = DateTime.Now, status = "nie", planowanaDataDostarczenia = DateTime.Now.AddDays(5), dataDostarczenia = DateTime.Now.AddDays(10)});
            orders.Add(new GetOrdersDTO { id = 5, nazwisko = "Kowalski", adres = "Warszawa", dataWyruszenia = DateTime.Now, status = "zrealizowana", planowanaDataDostarczenia = DateTime.Now.AddDays(5), dataDostarczenia = DateTime.Now.AddDays(10)});
            orders.Add(new GetOrdersDTO { id = 6, nazwisko = "Kowalski", adres = "Warszawa", dataWyruszenia = DateTime.Now, status = "zrealizowana", planowanaDataDostarczenia = DateTime.Now.AddDays(5), dataDostarczenia = DateTime.Now.AddDays(10)});
            return Ok(_service.GetOrders());
        }

        [HttpPost(Name = "AddOrder")]
        public IActionResult AddOrder([FromBody] AddOrderDTO addOrder)
        {      
            return Ok(_service.AddOrder(addOrder));
        }
    }
}
