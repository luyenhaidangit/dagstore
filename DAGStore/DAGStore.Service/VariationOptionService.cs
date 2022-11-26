using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IVariationOptionService
    {
        bool Add(VariationOption VariationOption);

        bool Update(VariationOption VariationOption);

        bool Delete(int id);

        IEnumerable<VariationOption> GetAll();

        VariationOption GetByID(int id);

        void SaveChanges();
    }

    public class VariationOptionService : IVariationOptionService
    {
        
        private IVariationOptionRepository _VariationOptionRepository;
        private IUnitOfWork _unitOfWork;

        public VariationOptionService(IVariationOptionRepository VariationOptionRepository, IUnitOfWork unitOfWork)
        {
            this._VariationOptionRepository = VariationOptionRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<VariationOption> GetAll()
        {
            return _VariationOptionRepository.GetAll();
        }


        public bool Add(VariationOption VariationOption)
        {
            return _VariationOptionRepository.Add(VariationOption);
        }

        public bool Delete(int id)
        {
            return _VariationOptionRepository.Delete(id);
        }

        public VariationOption GetByID(int id)
        {
            return _VariationOptionRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(VariationOption VariationOption)
        {
            return _VariationOptionRepository.Update(VariationOption);
        }
    }
}