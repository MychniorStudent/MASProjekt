using TransportAppAPI.Contexts;
using TransportAppAPI.DTOs;
using TransportAppAPI.Interfaces;

namespace TransportAppAPI.Implementations
{
    public class TransportService : ITransportService
    {
        TransportDbContext _context;
        public TransportService(TransportDbContext context)
        {
            _context = context;
        }

        public bool AddTransport(AddTransportDTO transport)
        {

            var transportowiec = new Models.SrodekTransportu
            {
                model = transport.model,
                marka = transport.marka,
                numerRejestracyjny = transport.nrRejestracyjny,
                czyMozeNiebezpieczne = transport.czyNiebezpieczne,
            };
            if (transport.czyWodny)
                transportowiec.TerenTransportera.Add(Enums.TerenTransportera.Wodny);

            if (transport.czyNaziemny)
                transportowiec.TerenTransportera.Add(Enums.TerenTransportera.Ladowy);

            if(transport.czyElektryczny)
                transportowiec.rodzajNapedu = Enums.RodzajNapedu.Elektryczny;
            else
                transportowiec.rodzajNapedu = Enums.RodzajNapedu.Spalinowy;

            _context.SrodkiTransportu.Add(transportowiec);
            _context.SaveChanges();
            throw new NotImplementedException();
        }

        public List<GetTransportsDTO> GetTransports()
        {
            //throw new NotImplementedException();
           return _context.SrodkiTransportu.Select(x=>new GetTransportsDTO
           {
               id = x.idSrodkaTransportu,
               marka = x.marka,
               model = x.model,
               czyMozeNiebezpieczne = x.czyMozeNiebezpieczne,
           }).ToList();
        }
    }
}
