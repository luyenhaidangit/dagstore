using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IImportBillDetailService
    {
        bool Add(ImportBillDetail importBillDetail);

        bool Update(ImportBillDetail importBillDetail);

        bool Delete(int id);

        IEnumerable<ImportBillDetail> GetAll();

        ImportBillDetail GetByID(int id);

        void SaveChanges();
    }

    public class ImportBillDetailService : IImportBillDetailService
    {
        private IImportBillDetailRepository _importBillDetailRepository;
        private IUnitOfWork _unitOfWork;

        public ImportBillDetailService(IImportBillDetailRepository importBillDetailRepository, IUnitOfWork unitOfWork)
        {
            this._importBillDetailRepository = importBillDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ImportBillDetail> GetAll()
        {
            return _importBillDetailRepository.GetAll();
        }


        public bool Add(ImportBillDetail importBillDetail)
        {
            return _importBillDetailRepository.Add(importBillDetail);
        }

        public bool Delete(int id)
        {
            return _importBillDetailRepository.Delete(id);
        }

        public ImportBillDetail GetByID(int id)
        {
            return _importBillDetailRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(ImportBillDetail importBillDetail)
        {
            return _importBillDetailRepository.Update(importBillDetail);
        }
    }
}