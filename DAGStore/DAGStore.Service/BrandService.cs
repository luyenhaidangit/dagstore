using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IBrandService
    {
        bool Add(Brand brand);

        bool Update(Brand brand);

        bool Delete(int id);

        IEnumerable<Brand> GetAll();

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
            return _brandRepository.GetAll();
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
    }
}