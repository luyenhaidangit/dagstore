using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;

namespace DAGStore.Service
{
    public interface ICategoryService
    {
        bool Add(Category category);

        bool Update(Category category);

        bool Delete(int id);

        IEnumerable<Category> GetAll();

        Category GetByID(int id);

        void SaveChanges();
    }

    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(Category Category)
        {
            return _categoryRepository.Add(Category);
        }

        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetByID(int id)
        {
            return _categoryRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
    }
}