using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Data.Repositories
{
    public interface IImportBillDetailRepository : IRepository<ImportBillDetail>
    {
    }

    public class ImportBillDetailRepository : RepositoryBase<ImportBillDetail>, IImportBillDetailRepository
    {
        public ImportBillDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
