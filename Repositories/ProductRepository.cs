using Login.Models;
using Login.Repositories.Interfaces;

namespace Login.Repositories
{
    public class ProductRepository : IProductRepository
    {

        public readonly AppSetingsDBContext _context;

        public ProductRepository(AppSetingsDBContext context)
        {

            _context = context;

        }

        public List<Product> GetProduct()
        {
            var products = _context.Products.ToList();

            if (products == null)
            {
                return null;
            }
            return products;
        }
    }
}
