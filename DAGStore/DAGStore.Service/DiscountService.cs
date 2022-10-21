using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;

namespace DAGStore.Service
{
    public interface IDiscountService
    {
        bool Add(Discount Discount);

        bool Update(Discount Discount);

        bool Delete(int id);

        IEnumerable<Discount> GetAll();

        Discount GetByID(int id);

        void SaveChanges();
    }

    public class DiscountService : IDiscountService
    {
        private IDiscountRepository _DiscountRepository;
        private IUnitOfWork _unitOfWork;

        public DiscountService(IDiscountRepository DiscountRepository, IUnitOfWork unitOfWork)
        {
            this._DiscountRepository = DiscountRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(Discount Discount)
        {
            return _DiscountRepository.Add(Discount);
        }

        public bool Delete(int id)
        {
            return _DiscountRepository.Delete(id);
        }

        public IEnumerable<Discount> GetAll()
        {
            return _DiscountRepository.GetAll();
        }

        public Discount GetByID(int id)
        {
            return _DiscountRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Discount Discount)
        {
            return _DiscountRepository.Update(Discount);
        }
    }
}