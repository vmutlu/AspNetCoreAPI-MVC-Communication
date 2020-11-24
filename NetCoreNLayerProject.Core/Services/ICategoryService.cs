using NetCoreNLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Core.Service
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductByIdAsync(int categoryId);
    }
}
