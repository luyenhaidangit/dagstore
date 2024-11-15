using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAGStore.Service
{
    public interface ISuggestProductService
    {
        bool Add(SuggestProduct SuggestProduct);

        bool Update(SuggestProduct SuggestProduct);

        bool Delete(int id);

        IEnumerable<SuggestProduct> GetAll();

        SuggestProduct GetByID(int id);

        bool DeleteSuggest(Expression<Func<SuggestProduct, bool>> where);

        void SaveChanges();
    }

    public class SuggestProductService : ISuggestProductService
    {
        private ISuggestProductRepository _SuggestProductRepository;
        private IUnitOfWork _unitOfWork;

        public SuggestProductService(ISuggestProductRepository SuggestProductRepository, IUnitOfWork unitOfWork)
        {
            this._SuggestProductRepository = SuggestProductRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<SuggestProduct> GetAll()
        {
            return _SuggestProductRepository.GetAll();
        }


        public bool Add(SuggestProduct SuggestProduct)
        {
            return _SuggestProductRepository.Add(SuggestProduct);
        }

        public bool DeleteSuggest(Expression<Func<SuggestProduct, bool>> where)
        {
            return _SuggestProductRepository.DeleteMulti(where);
        }

        public bool Delete(int id)
        {
            return _SuggestProductRepository.Delete(id);
        }

        public SuggestProduct GetByID(int id)
        {
            return _SuggestProductRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(SuggestProduct SuggestProduct)
        {
            return _SuggestProductRepository.Update(SuggestProduct);
        }
    }
}