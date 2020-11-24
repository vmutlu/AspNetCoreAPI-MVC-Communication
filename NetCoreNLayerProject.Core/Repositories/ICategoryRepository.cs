using NetCoreNLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Core.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductByIdAsync(int categoryId);
    }
}
