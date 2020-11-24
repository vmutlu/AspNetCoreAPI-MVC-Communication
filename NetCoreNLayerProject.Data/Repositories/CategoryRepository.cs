using Microsoft.EntityFrameworkCore;
using NetCoreNLayerProject.Core.Models;
using NetCoreNLayerProject.Core.Repository;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _applicationDbContext { get => _context as ApplicationDbContext; }
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
            return await _applicationDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
