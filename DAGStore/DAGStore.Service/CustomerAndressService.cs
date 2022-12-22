using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface ICustomerAndressService
    {
        bool Add(CustomerAndress CustomerAndress);

        bool Update(CustomerAndress CustomerAndress);

        bool Delete(int id);

        IEnumerable<CustomerAndress> GetAll();

        CustomerAndress GetByID(int id);

        void SaveChanges();
    }

    public class CustomerAndressService : ICustomerAndressService
    {
        private ICustomerAndressRepository _CustomerAndressRepository;
        private IUnitOfWork _unitOfWork;

        public CustomerAndressService(ICustomerAndressRepository CustomerAndressRepository, IUnitOfWork unitOfWork)
        {
            this._CustomerAndressRepository = CustomerAndressRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerAndress> GetAll()
        {
            return _CustomerAndressRepository.GetAll();
        }


        public bool Add(CustomerAndress CustomerAndress)
        {
            return _CustomerAndressRepository.Add(CustomerAndress);
        }

        public bool Delete(int id)
        {
            return _CustomerAndressRepository.Delete(id);
        }

        public CustomerAndress GetByID(int id)
        {
            return _CustomerAndressRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(CustomerAndress CustomerAndress)
        {
            return _CustomerAndressRepository.Update(CustomerAndress);
        }
    }
}