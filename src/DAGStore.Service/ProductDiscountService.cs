using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;

namespace DAGStore.Service
{
    public interface IProductDiscountService
    {
        bool Add(ProductDiscount ProductDiscount);

        bool Update(ProductDiscount ProductDiscount);

        bool Delete(int id);

        bool DeleteMultiByProductID(int id);

        IEnumerable<ProductDiscount> GetAll();

        ProductDiscount GetByID(int id);

        void SaveChanges();
    }

    public class ProductDiscountService : IProductDiscountService
    {
        private IProductDiscountRepository _ProductDiscountRepository;
        private IUnitOfWork _unitOfWork;

        public ProductDiscountService(IProductDiscountRepository ProductDiscountRepository, IUnitOfWork unitOfWork)
        {
            this._ProductDiscountRepository = ProductDiscountRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(ProductDiscount ProductDiscount)
        {
            return _ProductDiscountRepository.Add(ProductDiscount);
        }

        public bool Delete(int id)
        {
            return _ProductDiscountRepository.Delete(id);
        }

        public bool DeleteMultiByProductID(int id)
        {
            return _ProductDiscountRepository.DeleteMulti(x=>x.ProductID==id);
        }

        public IEnumerable<ProductDiscount> GetAll()
        {
            return _ProductDiscountRepository.GetAll();
        }

        public ProductDiscount GetByID(int id)
        {
            return _ProductDiscountRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(ProductDiscount ProductDiscount)
        {
            return _ProductDiscountRepository.Update(ProductDiscount);
        }
    }
}