using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace DAGStore.Service
{
    public interface IImportBillService
    {
        bool Add(ImportBill importBill);

        bool Update(ImportBill importBill);

        bool Delete(int id);

        IEnumerable<ImportBill> GetAll();

        IEnumerable<dynamic> GetList();

        dynamic GetInfo(int id);

        ImportBill GetByID(int id);

        void SaveChanges();
    }

    public class ImportBillService : IImportBillService
    {
        private IImportBillRepository _importBillRepository;
        private ISupplierRepository _supplierRepository;
        private IImportBillDetailRepository _importBillDetailRepository;
        private IUnitOfWork _unitOfWork;

        public ImportBillService(IImportBillRepository importBillRepository, ISupplierRepository supplierRepository,IImportBillDetailRepository importBillDetailRepository, IUnitOfWork unitOfWork)
        {
            this._importBillRepository = importBillRepository;
            this._supplierRepository = supplierRepository;
            this._importBillDetailRepository = importBillDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ImportBill> GetAll()
        {
            return _importBillRepository.GetAll();
        }

        public IEnumerable<dynamic> GetList()
        {
            var importBill = _importBillRepository.GetAll();

            var result = from i in importBill        
                         select new
                         {
                             ID = i.ID,
                             ImportBillCode = i.ImportBillCode,
                             NameSupplier = _supplierRepository.GetSingleByID(i.SupplierID).Name,
                             TotalPriceBill = i.TotalPriceBill,
                             TotalDiscount = i.TotalDiscount,
                             ActualPriceBill = i.ActualPriceBill,
                             Description = i.Description,
                             Status = i.Status,
                             CreateOn = i.CreateOn.ToString("dd-MM-yyyy"),
                             ImportBills = _importBillDetailRepository.GetMulti(x=>x.ImportBillID == i.ID),
                         }; 
            return result;
        }

        public dynamic GetInfo(int id)
        {
            var importBill = GetList().FirstOrDefault(x=> x.ID == id);

            return importBill;
        }

        public bool Add(ImportBill importBill)
        {
            return _importBillRepository.Add(importBill);
        }

        public bool Delete(int id)
        {
            return _importBillRepository.Delete(id);
        }

        public ImportBill GetByID(int id)
        {
            return _importBillRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(ImportBill importBill)
        {
            return _importBillRepository.Update(importBill);
        }
    }
}