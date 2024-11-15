using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface IProductDiscountRepository : IRepository<ProductDiscount>
    {
    }

    public class ProductDiscountRepository : RepositoryBase<ProductDiscount>, IProductDiscountRepository
    {
        public ProductDiscountRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
