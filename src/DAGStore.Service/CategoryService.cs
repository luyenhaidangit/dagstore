using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace DAGStore.Service
{
    public interface ICategoryService
    {
        bool Add(Category category);

        bool Update(Category category);

        bool Delete(int id);

        IEnumerable<Category> GetAll();

        IEnumerable<Category> GetCategoryShowOnHomePage();

        IEnumerable<Category> GetListChildCategory(int id);

        Category GetByID(int id);

        IEnumerable<dynamic> GetData();

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

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll().Where(x => x.Deleted != true);
        }

        public IEnumerable<Category> GetCategoryShowOnHomePage()
        {
            var categories = _categoryRepository.GetAll().ToList();
            var list = (from t in categories
                        where t.Published == true && t.ParentCategoryID == 0
                        orderby t.DisplayOrder descending
                        select t).Take(10);
            return list;
        }

        public IEnumerable<Category> GetListChildCategory(int id)
        {
            var categories = _categoryRepository.GetAll().ToList();
            var list = (from t in categories
                        where t.ParentCategoryID == id
                        orderby t.DisplayOrder descending
                        select t);
            return list;
        }

        public bool Add(Category Category)
        {
            return _categoryRepository.Add(Category);
        }

        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
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

        public IEnumerable<dynamic> GetData()
        {
            var category = GetAll();
            var result = (from c in category
                          select new
                          {
                              ID = c.ID,
                              ParentCategoryID = c.ParentCategoryID,
                              Name = c.Name,
                              PicturePath = c.PicturePath,
                              Description = c.Description,
                              DisplayOrder = c.DisplayOrder,
                              Published = c.Published,
                              Deleted = c.Deleted,
                              NameParentCategory = _categoryRepository.GetSingleByID(c.ParentCategoryID) == null ? "---" : _categoryRepository.GetSingleByID(c.ParentCategoryID).Name,
                          });
            return result;  
        }

    }
}