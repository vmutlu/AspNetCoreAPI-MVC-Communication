using NetCoreNLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Core.Repository
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
