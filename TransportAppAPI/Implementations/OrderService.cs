using System.Net;
using TransportAppAPI.Contexts;
using TransportAppAPI.DTOs;
using TransportAppAPI.Interfaces;
using TransportAppAPI.Models;

namespace TransportAppAPI.Implementations
{
    public class OrderService : IOrderService
    {
        TransportDbContext _context;
        public OrderService(TransportDbContext context)
        {
            _context = context;
        }

        public bool AddOrder(AddOrderDTO order)
        {
            int IdPlacowkiToAssign = _context.Placowki.First().idPlacowki;

            var IdPracownika = _context.Osoby.Where(x => x.idPlacowki == IdPlacowkiToAssign).First().idPracownika;
            var zlecenieTransportu = new ZlecenieTransportu
            {
                adres = order.adresDostawy,
                idSrodekTransportu = order.idTransportu,
                daneTransportowe = new DaneTransportowe
                {
                    planowanaDataDostarczenia = order.planowanaDataDostraczenia,
                    dataWyruszenia = order.dataWyruszenia,
                    idPlacowki = IdPlacowkiToAssign,
                },
                status = "W trakcie realizacji",
                idPrzewoznika = IdPracownika
            };
            _context.ZleceniaTransportu.Add(zlecenieTransportu);
            _context.SaveChanges();
            order.idProduktow.ForEach(x =>
            {
                _context.Towary.FirstOrDefault(y => y.id == x).idTransportu = zlecenieTransportu.id;
            });
            _context.SaveChanges();
            return true;
        }

        public List<GetOrdersDTO> GetOrders()
        {
            //throw new NotImplementedException();
            return _context.ZleceniaTransportu.Select(x => new GetOrdersDTO
            {
                id = x.id,
                nazwisko = _context.Osoby.Where(y=>y.idPracownika == x.idPrzewoznika).FirstOrDefault().nazwisko,
                status = x.status,
                dataWyruszenia = x.daneTransportowe.dataWyruszenia,
                planowanaDataDostarczenia = x.daneTransportowe.planowanaDataDostarczenia,
                dataDostarczenia = x.daneTransportowe.dataDostarczenia.HasValue ? x.daneTransportowe.dataDostarczenia : null,
                adres = x.adres

            }).ToList();

        }
    }
}
