using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface ICustomerService
    {
        bool Add(Customer Customer);

        bool Update(Customer Customer);

        bool Delete(int id);

        IEnumerable<Customer> GetAll();

        Customer GetByID(int id);

        void SaveChanges();
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _CustomerRepository;
        private IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository CustomerRepository, IUnitOfWork unitOfWork)
        {
            this._CustomerRepository = CustomerRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _CustomerRepository.GetAll();
        }


        public bool Add(Customer Customer)
        {
            return _CustomerRepository.Add(Customer);
        }

        public bool Delete(int id)
        {
            return _CustomerRepository.Delete(id);
        }

        public Customer GetByID(int id)
        {
            return _CustomerRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Customer Customer)
        {
            return _CustomerRepository.Update(Customer);
        }
    }
}