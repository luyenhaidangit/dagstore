using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;

namespace DAGStore.Service
{
    public interface IProductService
    {
        bool Add(Product menuRecord);

        bool Update(Product menuRecord);

        bool Delete(int id);

        IEnumerable<Product> GetAll();

        Product GetByID(int id);

        void SaveChanges();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetByID(int id)
        {
            return _productRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Product menuRecord)
        {
            return _productRepository.Update(menuRecord);
        }
    }
}