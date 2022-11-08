using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface ISuggestService
    {
        bool Add(Suggest Suggest);

        bool Update(Suggest Suggest);

        bool Delete(int id);

        IEnumerable<Suggest> GetAll();

        Suggest GetByID(int id);

        void SaveChanges();
    }

    public class SuggestService : ISuggestService
    {
        private ISuggestRepository _SuggestRepository;
        private IUnitOfWork _unitOfWork;

        public SuggestService(ISuggestRepository SuggestRepository, IUnitOfWork unitOfWork)
        {
            this._SuggestRepository = SuggestRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Suggest> GetAll()
        {
            return _SuggestRepository.GetAll();
        }


        public bool Add(Suggest Suggest)
        {
            return _SuggestRepository.Add(Suggest);
        }

        public bool Delete(int id)
        {
            return _SuggestRepository.Delete(id);
        }

        public Suggest GetByID(int id)
        {
            return _SuggestRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Suggest Suggest)
        {
            return _SuggestRepository.Update(Suggest);
        }
    }
}