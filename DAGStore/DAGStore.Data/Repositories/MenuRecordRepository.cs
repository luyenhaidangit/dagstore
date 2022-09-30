using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface IMenuRecordRepository : IRepository<MenuRecord>
    {
    }

    public class MenuRecordRepository : RepositoryBase<MenuRecord>, IMenuRecordRepository
    {
        public MenuRecordRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}