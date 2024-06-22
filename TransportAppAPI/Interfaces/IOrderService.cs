using TransportAppAPI.DTOs;

namespace TransportAppAPI.Interfaces
{
    public interface IOrderService
    {
        List<GetOrdersDTO> GetOrders();
        bool AddOrder(AddOrderDTO order);
    }
}
