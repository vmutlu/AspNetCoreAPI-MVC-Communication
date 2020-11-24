using NetCoreNLayerProject.Core.Repository;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //Best Practive için Repositoryler eklendi.
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        Task CommitAsync();
        void Commit();
    }
}
