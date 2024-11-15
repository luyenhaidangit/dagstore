using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface ICustomerAndressRepository : IRepository<CustomerAndress>
    {
    }

    public class CustomerAndressRepository : RepositoryBase<CustomerAndress>, ICustomerAndressRepository
    {
        public CustomerAndressRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}