using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Data.Repositories
{
    public interface IImportBillRepository : IRepository<ImportBill>
    {
    }

    public class ImportBillRepository : RepositoryBase<ImportBill>, IImportBillRepository
    {
        public ImportBillRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
