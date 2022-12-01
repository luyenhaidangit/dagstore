using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
    }

    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
