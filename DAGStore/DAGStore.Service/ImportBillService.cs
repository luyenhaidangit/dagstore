using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IImportBillService
    {
        bool Add(ImportBill importBill);

        bool Update(ImportBill importBill);

        bool Delete(int id);

        IEnumerable<ImportBill> GetAll();

        IEnumerable<dynamic> GetData();

        ImportBill GetByID(int id);

        void SaveChanges();
    }

    public class ImportBillService : IImportBillService
    {
        private IImportBillRepository _importBillRepository;
        private ISupplierService _supplierService;
        private IUnitOfWork _unitOfWork;

        public ImportBillService(IImportBillRepository importBillRepository, ISupplierService supplierService, IUnitOfWork unitOfWork)
        {
            this._importBillRepository = importBillRepository;
            this._supplierService = supplierService;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ImportBill> GetAll()
        {
            return _importBillRepository.GetAll();
        }

        public IEnumerable<dynamic> GetData()
        {
            var importBill = _importBillRepository.GetAll();
            var supplier = _supplierService.GetAll();

            var result = from i in importBill
                         join s in supplier on i.SupplierID equals s.ID
                         select new
                         {
                             ImportBill = i,
                             Supplier = s
                         }; 
            return result;
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