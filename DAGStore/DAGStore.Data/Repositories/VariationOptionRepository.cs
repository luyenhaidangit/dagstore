using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface IVariationOptionRepository : IRepository<VariationOption>
    {
    }

    public class VariationOptionRepository : RepositoryBase<VariationOption>, IVariationOptionRepository
    {
        public VariationOptionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
