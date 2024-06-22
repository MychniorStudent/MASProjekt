using TransportAppAPI.Contexts;
using TransportAppAPI.DTOs;
using TransportAppAPI.Interfaces;

namespace TransportAppAPI.Implementations
{
    public class ProductService : IProductService
    {
        TransportDbContext _context;
        public ProductService(TransportDbContext context)
        {
            _context = context;
        }

        public bool AddProduct(AddProductDTO product)
        {
            _context.Towary.Add(new Models.Towar { 
                ilosc = product.ilosc,
                nazwa = product.nazwa,
                kategoria = product.kategoria,
                czyNiebezpieczne = product.czyNiebezpieczny
                });
            _context.SaveChanges();
            return true;
            //throw new NotImplementedException();
        }

        public List<GetProductsDTO> GetProducts()
        {
            //throw new NotImplementedException();
            return _context.Towary.Select(x=>new GetProductsDTO { id = x.id, nazwa = x.nazwa, ilosc = x.ilosc, czyNiebezpieczny = x.czyNiebezpieczne, kategoria = x.kategoria }).ToList();
        }

        public List<GetProductsDTO> GetProductsByOrderId(int orderId)
        {
            return _context.Towary.Where(x=>x.idTransportu == orderId).Select(x => new GetProductsDTO { id = x.id, nazwa = x.nazwa, ilosc = x.ilosc, czyNiebezpieczny = x.czyNiebezpieczne, kategoria = x.kategoria }).ToList();

        }

        public List<GetProductsDTO> GetProductsWithoutOrderId()
        {
            var hehe = _context.Towary.ToList();
            var towary = _context.Towary.Where(x => x.idTransportu == null).Select(x => new GetProductsDTO
            { id = x.id, nazwa = x.nazwa, ilosc = x.ilosc, czyNiebezpieczny = x.czyNiebezpieczne, kategoria = x.kategoria }).ToList();
            return towary;
        }
    }
}
