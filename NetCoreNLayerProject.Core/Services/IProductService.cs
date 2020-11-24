using NetCoreNLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Core.Service
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
