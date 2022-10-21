using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface IDiscountRepository : IRepository<Discount>
    {
    }

    public class DiscountRepository : RepositoryBase<Discount>, IDiscountRepository
    {
        public DiscountRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
