using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Data.Repositories
{
    public interface IImportBillDetailRepository : IRepository<ImportBillDetail>
    {
        IEnumerable<dynamic> GetImportBillDetailsByImportBill(int id);
    }

    public class ImportBillDetailRepository : RepositoryBase<ImportBillDetail>, IImportBillDetailRepository
    {
        public ImportBillDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<dynamic> GetImportBillDetailsByImportBill(int id)
        {
            var importbilldetail = GetAll();


            var result = from i in importbilldetail
                         select new
                         {
                             ID = i.ID,
                             ImportBillID = i.ImportBillID,
                             ProductID = i.ProductID,
                             Quantity = i.Quantity,
                             ImportPrice = i.ImportPrice,
                             Discount = i.Discount,
                             TotalImportPrice = i.TotalImportPrice,
                             Name = i.Product.Name,
                             PicturePath = i.Product.PicturePath,
                         };
            return result;
        }
    }
}
