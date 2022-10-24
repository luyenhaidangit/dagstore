using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

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
