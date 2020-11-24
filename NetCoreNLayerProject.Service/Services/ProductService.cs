using NetCoreNLayerProject.Core.Models;
using NetCoreNLayerProject.Core.Repository;
using NetCoreNLayerProject.Core.Service;
using NetCoreNLayerProject.Core.UnitOfWorks;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
