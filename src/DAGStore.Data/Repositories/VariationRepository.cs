using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface IVariationRepository : IRepository<Variation>
    {
    }

    public class VariationRepository : RepositoryBase<Variation>, IVariationRepository
    {
        public VariationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
