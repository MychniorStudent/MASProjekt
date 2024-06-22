using TransportAppAPI.DTOs;

namespace TransportAppAPI.Interfaces
{
    public interface ITransportService
    {
        List<GetTransportsDTO> GetTransports();
        bool AddTransport(AddTransportDTO transport);
    }
}
