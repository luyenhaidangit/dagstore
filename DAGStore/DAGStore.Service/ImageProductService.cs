using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IImageProductService
    {
        IEnumerable<ImageProduct> GetAll();

        ImageProduct GetByID(int id);

        bool Add(ImageProduct ImageProduct);

        bool Update(ImageProduct ImageProduct);

        bool Delete(int id);

        void SaveChanges();
    }

    public class ImageProductService : IImageProductService
    {
        private IImageProductRepository _ImageProductRepository;
        private IUnitOfWork _unitOfWork;

        public ImageProductService(IImageProductRepository ImageProductRepository, IUnitOfWork unitOfWork)
        {
            this._ImageProductRepository = ImageProductRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ImageProduct> GetAll()
        {
            return _ImageProductRepository.GetAll().ToList();
        }


        public bool Add(ImageProduct ImageProduct)
        {
            return _ImageProductRepository.Add(ImageProduct);
        }

        public bool Delete(int id)
        {
            return _ImageProductRepository.Delete(id);
        }

        public ImageProduct GetByID(int id)
        {
            return _ImageProductRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(ImageProduct ImageProduct)
        {
            return _ImageProductRepository.Update(ImageProduct);
        }
    }
}