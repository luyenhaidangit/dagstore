using DAGStore.Data.Infrastructure;
using DAGStore.Data.Migrations;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IProductService
    {
        bool Add(Product menuRecord);

        bool Update(Product menuRecord);

        bool Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<dynamic> GetProductsNewShowHomePage();

        IEnumerable<dynamic> GetData();

        dynamic GetInfo(int id);

        Product GetByID(int id);

        void SaveChanges();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IBrandRepository _brandRepository;
        private ICategoryRepository _categoryRepository;
        private IDiscountService _discountService;
        private IProductDiscountService _productDiscountService;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,IDiscountService discountService, IProductDiscountService productDiscountService, IUnitOfWork unitOfWork, IBrandRepository brandService, ICategoryRepository categoryService)
        {
            this._discountService = discountService;
            this._productRepository = productRepository;
            this._productDiscountService = productDiscountService;
            this._unitOfWork = unitOfWork;
            this._brandRepository = brandService;
            this._categoryRepository = categoryService;
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
            return _productRepository.GetAll().Where(x => x.Deleted != true);
        }

        public IEnumerable<dynamic> GetData()
        {
            var product = GetAll();
            var result = (from c in product
                          select new
                          {
                              ID = c.ID,
                              Name = c.Name,
                              PicturePath = c.PicturePath,
                              ShortDescription = c.ShortDescription,
                              FullDescription = c.FullDescription,
                              ShortDescriptionEndow = c.ShortDescriptionEndow,
                              NameCategory = _categoryRepository.GetSingleByID(c.CategoryID).Name,
                              NameBrand = _brandRepository.GetSingleByID(c.BrandID).Name,
                              CostPrice = c.CostPrice,
                              SellPrice = c.SellPrice,
                              InventoryQuantity = c.InventoryQuantity,
                              MinimumInventoryQuantity = c.MinimumInventoryQuantity,
                              MaximumInventoryQuantity = c.MaximumInventoryQuantity,
                              DisplayOrder = c.DisplayOrder,
                              Published = c.Published,
                          });
            return result;
        }

        public IEnumerable<dynamic> GetProductsNewShowHomePage()
        {
            var discounts = _discountService.GetAll();
            var productDiscounts = _productDiscountService.GetAll();
            var products = _productRepository.GetAll();
            products = products.Reverse();
            var result = (from p in products
                          where p.Published == true
                          select new
                          {
                              IDProduct = p.ID,
                              NameProduct = p.Name,
                              PriceProduct = p.SellPrice,
                              ImageProduct = p.PicturePath,
                              DescriptionProduct = p.ShortDescriptionEndow,
                              Discount = _discountService.GetDiscountByProduct(p.ID).Take(2),
                          }).Take(20); ;
            return result;
        }

        public Product GetByID(int id)
        {
            return _productRepository.GetSingleByID(id);
        }

        public dynamic GetInfo(int id)
        {
            var product = _productRepository.GetSingleByID(id);
            var result = (new
                          {
                              ID = product.ID,
                              Name = product.Name,
                              PicturePath = product.PicturePath,
                              ShortDescription = product.ShortDescription,
                              FullDescription = product.FullDescription,
                              ShortDescriptionEndow = product.ShortDescriptionEndow,
                              NameCategory = _categoryRepository.GetSingleByID(product.CategoryID).Name,
                              NameBrand = _brandRepository.GetSingleByID(product.BrandID).Name,
                              CostPrice = product.CostPrice,
                              SellPrice = product.SellPrice,
                              InventoryQuantity = product.InventoryQuantity,
                              MinimumInventoryQuantity = product.MinimumInventoryQuantity,
                              MaximumInventoryQuantity = product.MaximumInventoryQuantity,
                              DisplayOrder = product.DisplayOrder,
                              Published = product.Published,
                          });
            return result;
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