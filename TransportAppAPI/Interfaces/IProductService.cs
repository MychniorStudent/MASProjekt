using TransportAppAPI.DTOs;

namespace TransportAppAPI.Interfaces
{
    public interface IProductService
    {
        List<GetProductsDTO> GetProducts();
        List<GetProductsDTO> GetProductsByOrderId(int orderId);
        List<GetProductsDTO> GetProductsWithoutOrderId();
        bool AddProduct(AddProductDTO product);
    }
}
