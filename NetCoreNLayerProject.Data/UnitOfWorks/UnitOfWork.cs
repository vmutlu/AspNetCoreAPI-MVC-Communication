using NetCoreNLayerProject.Core.Repository;
using NetCoreNLayerProject.Core.UnitOfWorks;
using NetCoreNLayerProject.Data.Repositories;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_applicationDbContext);
        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_applicationDbContext);

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Commit()
        {
            _applicationDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
