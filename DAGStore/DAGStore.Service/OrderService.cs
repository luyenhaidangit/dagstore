using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IOrderService
    {
        bool Add(Order Order);

        bool Update(Order Order);

        bool Delete(int id);

        IEnumerable<Order> GetAll();

        Order GetByID(int id);

        void SaveChanges();
    }

    public class OrderService : IOrderService
    {
        private IOrderRepository _OrderRepository;
        private IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository OrderRepository, IUnitOfWork unitOfWork)
        {
            this._OrderRepository = OrderRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> GetAll()
        {
            return _OrderRepository.GetAll();
        }


        public bool Add(Order Order)
        {
            return _OrderRepository.Add(Order);
        }

        public bool Delete(int id)
        {
            return _OrderRepository.Delete(id);
        }

        public Order GetByID(int id)
        {
            return _OrderRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Order Order)
        {
            return _OrderRepository.Update(Order);
        }
    }
}