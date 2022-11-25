using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IPageService
    {
        bool Add(Page Page);

        bool Update(Page Page);

        bool Delete(int id);

        IEnumerable<Page> GetAll();

        Page GetByID(int id);

        void SaveChanges();
    }

    public class PageService : IPageService
    {
        private IPageRepository _PageRepository;
        private IUnitOfWork _unitOfWork;

        public PageService(IPageRepository PageRepository, IUnitOfWork unitOfWork)
        {
            this._PageRepository = PageRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Page> GetAll()
        {
            return _PageRepository.GetAll();
        }


        public bool Add(Page Page)
        {
            return _PageRepository.Add(Page);
        }

        public bool Delete(int id)
        {
            return _PageRepository.Delete(id);
        }

        public Page GetByID(int id)
        {
            return _PageRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Page Page)
        {
            return _PageRepository.Update(Page);
        }
    }
}