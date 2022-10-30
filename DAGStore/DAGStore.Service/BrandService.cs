using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IBrandService
    {
        List<Brand> GetAllBrand();

        bool Add(Brand brand);

        bool Update(Brand brand);

        bool Delete(int id);

        IEnumerable<Brand> GetAll();

        IEnumerable<dynamic> GetData();

        Brand GetByID(int id);

        void SaveChanges();
    }

    public class BrandService : IBrandService
    {
        private IBrandRepository _brandRepository;
        private IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            this._brandRepository = brandRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Brand> GetAll()
        {
            return _brandRepository.GetAll().Where(x => x.Deleted != true);
        }

       
        public bool Add(Brand brand)
        {
            return _brandRepository.Add(brand);
        }

        public bool Delete(int id)
        {
            return _brandRepository.Delete(id);
        }

        public Brand GetByID(int id)
        {
            return _brandRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Brand brand)
        {
            return _brandRepository.Update(brand);
        }

        public IEnumerable<dynamic> GetData()
        {
            var brand = GetAll();
            var result = (from c in brand
                          select new
                          {
                              ID = c.ID,
                              Name = c.Name,
                              PicturePath = c.PicturePath,
                              Description = c.Description,
                              DisplayOrder = c.DisplayOrder,
                              Published = c.Published,
                              Deleted = c.Deleted,
                          });
            return result;
        }

        public List<Brand> GetAllBrand()
        {
            return _brandRepository.GetAllBrand();
        }
    }
}