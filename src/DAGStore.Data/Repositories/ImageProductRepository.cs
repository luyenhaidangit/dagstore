using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface IImageProductRepository : IRepository<ImageProduct>
    {
    }

    public class ImageProductRepository : RepositoryBase<ImageProduct>, IImageProductRepository
    {
        public ImageProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
