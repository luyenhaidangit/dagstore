using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface ISupplierService
    {
        bool Add(Supplier Supplier);

        bool Update(Supplier Supplier);

        bool Delete(int id);

        IEnumerable<Supplier> GetAll();

        Supplier GetByID(int id);

        void SaveChanges();
    }

    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _supplierRepository;
        private IUnitOfWork _unitOfWork;

        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            this._supplierRepository = supplierRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _supplierRepository.GetAll().Where(x=>x.Deleted!=true);
        }


        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }

        public bool Delete(int id)
        {
            return _supplierRepository.Delete(id);
        }

        public Supplier GetByID(int id)
        {
            return _supplierRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Supplier supplier)
        {
            return _supplierRepository.Update(supplier);
        }
    }
}