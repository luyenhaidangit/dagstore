using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Data.Repositories
{
    public interface IMenuItemRecordRepository : IRepository<MenuItemRecord>
    {
        IEnumerable<MenuItemRecord> GetAllByMenuRecord(string menuRecord, int pageIndex, int pageSize, out int totalRow);
    }

    public class MenuRecordItemRepository : RepositoryBase<MenuItemRecord>, IMenuItemRecordRepository
    {
        public MenuRecordItemRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<MenuItemRecord> GetAllByMenuRecord(string menuRecord, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from mi in DbContext.MenuItemRecord
                        join m in DbContext.MenuRecord
                        on mi.ID equals m.ID
                        where m.Name == menuRecord && mi.Published
                        orderby mi.DisplayOrder descending
                        select mi;

            totalRow = query.Count();

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}