using NetCoreNLayerProject.Core.Models;
using NetCoreNLayerProject.Core.Repository;
using NetCoreNLayerProject.Core.Service;
using NetCoreNLayerProject.Core.UnitOfWorks;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductByIdAsync(categoryId);
        }
    }
}
