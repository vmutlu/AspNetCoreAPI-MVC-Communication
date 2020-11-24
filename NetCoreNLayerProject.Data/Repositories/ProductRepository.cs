using Microsoft.EntityFrameworkCore;
using NetCoreNLayerProject.Core.Models;
using NetCoreNLayerProject.Core.Repository;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _applicationDbContext { get => _context as ApplicationDbContext; }
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            var product = await _applicationDbContext.Products.Include(i => i.Category).SingleOrDefaultAsync(i => i.Id == productId);
            return product;
        }
    }
}
