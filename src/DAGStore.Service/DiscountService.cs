using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace DAGStore.Service
{
    public interface IDiscountService
    {
        bool Add(Discount Discount);

        bool Update(Discount Discount);

        bool Delete(int id);

        IEnumerable<Discount> GetAll();

        IEnumerable<dynamic> GetListProductDiscount();

        IEnumerable<Discount> GetDiscountByProduct(int id);

        Discount GetByID(int id);

        void SaveChanges();
    }

    public class DiscountService : IDiscountService
    {
        private IDiscountRepository _DiscountRepository;
        private IProductRepository _productRepository;
        private IProductDiscountService _productDiscountRepository;
        private IUnitOfWork _unitOfWork;

        public DiscountService(IDiscountRepository DiscountRepository, IProductRepository productRepository, IProductDiscountService productDiscountRepository,IUnitOfWork unitOfWork)
        {
            this._DiscountRepository = DiscountRepository;
            this._productRepository = productRepository;
            this._productDiscountRepository = productDiscountRepository;
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

        public IEnumerable<Discount> GetDiscountByProduct(int id)
        {
            var product = _productRepository.GetAll();
            var discount = _DiscountRepository.GetAll();
            var productDiscount = _productDiscountRepository.GetAll();

            var result = from p in product
                         join pd in productDiscount on p.ID equals pd.ProductID
                         join d in discount on pd.DiscountID equals d.ID
                         where pd.ProductID == id
                         select d;
            return result;
        }

        public IEnumerable<dynamic> GetListProductDiscount()
        {
            var discount = _DiscountRepository.GetAll();
            var result = from c in discount 
                         select new
                         {
                             ID = c.ID,
                             Name = c.Name
                         };
            return result;
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