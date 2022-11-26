using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IVariationService
    {
        bool Add(Variation Variation);

        bool Update(Variation Variation);

        bool Delete(int id);

        IEnumerable<Variation> GetAll();

        Variation GetByID(int id);

        void SaveChanges();
    }

    public class VariationService : IVariationService
    {
        private IVariationRepository _VariationRepository;
        private IUnitOfWork _unitOfWork;

        public VariationService(IVariationRepository VariationRepository, IUnitOfWork unitOfWork)
        {
            this._VariationRepository = VariationRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Variation> GetAll()
        {
            return _VariationRepository.GetAll();
        }


        public bool Add(Variation Variation)
        {
            return _VariationRepository.Add(Variation);
        }

        public bool Delete(int id)
        {
            return _VariationRepository.Delete(id);
        }

        public Variation GetByID(int id)
        {
            return _VariationRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Variation Variation)
        {
            return _VariationRepository.Update(Variation);
        }
    }
}