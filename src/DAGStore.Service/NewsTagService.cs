using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface INewsTagService
    {
        bool Add(NewsTag NewsTag);

        bool Update(NewsTag NewsTag);

        bool Delete(int id);

        IEnumerable<NewsTag> GetAll();

        NewsTag GetByID(int id);

        void SaveChanges();
    }

    public class NewsTagService : INewsTagService
    {
        private INewsTagRepository _NewsTagRepository;
        private IUnitOfWork _unitOfWork;

        public NewsTagService(INewsTagRepository NewsTagRepository, IUnitOfWork unitOfWork)
        {
            this._NewsTagRepository = NewsTagRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<NewsTag> GetAll()
        {
            return _NewsTagRepository.GetAll();
        }


        public bool Add(NewsTag NewsTag)
        {
            return _NewsTagRepository.Add(NewsTag);
        }

        public bool Delete(int id)
        {
            return _NewsTagRepository.Delete(id);
        }

        public NewsTag GetByID(int id)
        {
            return _NewsTagRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(NewsTag NewsTag)
        {
            return _NewsTagRepository.Update(NewsTag);
        }
    }
}