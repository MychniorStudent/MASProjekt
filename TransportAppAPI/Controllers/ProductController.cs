using Microsoft.AspNetCore.Mvc;
using TransportAppAPI.Contexts;
using TransportAppAPI.DTOs;
using TransportAppAPI.Enums;
using TransportAppAPI.Interfaces;
using TransportAppAPI.Models;

namespace TransportAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        [ActionName("GetProducts")]
        public IActionResult GetProducts()
        {
            return Ok(_service.GetProducts());
        }
        [HttpGet]
        [ActionName("GetProductForOrderById")]
        public IActionResult GetProductForOrderById(int orderId)
        {
            return Ok(_service.GetProductsByOrderId(orderId));
        }
        [HttpGet]
        [ActionName("GetProductsWithoutOrderId")]
        public IActionResult GetProductsWithoutOrderId()
        {
            return Ok(_service.GetProductsByOrderId(1));
        }

        [HttpPost(Name = "AddProduct")]
        public IActionResult AddProduct([FromBody] AddProductDTO productDTO)
        {
            return Ok(_service.AddProduct(productDTO));
        }
    }
}
