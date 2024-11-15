using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IOrderItemService
    {
        bool Add(OrderItem OrderItem);

        bool Update(OrderItem OrderItem);

        bool Delete(int id);

        IEnumerable<OrderItem> GetAll();

        OrderItem GetByID(int id);

        IEnumerable<OrderItem> GetOrderItemsByOrder(int id);

        void SaveChanges();
    }

    public class OrderItemService : IOrderItemService
    {
        private IOrderItemRepository _OrderItemRepository;
        private IUnitOfWork _unitOfWork;

        public OrderItemService(IOrderItemRepository OrderItemRepository, IUnitOfWork unitOfWork)
        {
            this._OrderItemRepository = OrderItemRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _OrderItemRepository.GetAll();
        }

        public IEnumerable<OrderItem> GetOrderItemsByOrder(int id)
        {
            var listOrderItem = _OrderItemRepository.GetAll().Where(x => x.OrderID == id);
            return listOrderItem;
        }

            public bool Add(OrderItem OrderItem)
        {
            return _OrderItemRepository.Add(OrderItem);
        }

        public bool Delete(int id)
        {
            return _OrderItemRepository.Delete(id);
        }

        public OrderItem GetByID(int id)
        {
            return _OrderItemRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(OrderItem OrderItem)
        {
            return _OrderItemRepository.Update(OrderItem);
        }
    }
}