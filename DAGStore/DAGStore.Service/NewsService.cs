using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface INewsService
    {
        bool Add(News News);

        bool Update(News News);

        bool Delete(int id);

        IEnumerable<News> GetAll();

        News GetByID(int id);

        void SaveChanges();
    }

    public class NewsService : INewsService
    {
        private INewsRepository _NewsRepository;
        private IUnitOfWork _unitOfWork;

        public NewsService(INewsRepository NewsRepository, IUnitOfWork unitOfWork)
        {
            this._NewsRepository = NewsRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<News> GetAll()
        {
            return _NewsRepository.GetAll();
        }


        public bool Add(News News)
        {
            return _NewsRepository.Add(News);
        }

        public bool Delete(int id)
        {
            return _NewsRepository.Delete(id);
        }

        public News GetByID(int id)
        {
            return _NewsRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(News News)
        {
            return _NewsRepository.Update(News);
        }
    }
}