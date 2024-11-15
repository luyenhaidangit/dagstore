using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface ISliderService
    {
        bool Add(Slider Slider);

        bool Update(Slider Slider);

        bool Delete(int id);

        IEnumerable<Slider> GetAll();

        Slider GetByID(int id);

        void SaveChanges();
    }

    public class SliderService : ISliderService
    {
        private ISliderRepository _SliderRepository;
        private IUnitOfWork _unitOfWork;

        public SliderService(ISliderRepository SliderRepository, IUnitOfWork unitOfWork)
        {
            this._SliderRepository = SliderRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Slider> GetAll()
        {
            return _SliderRepository.GetAll();
        }


        public bool Add(Slider Slider)
        {
            return _SliderRepository.Add(Slider);
        }

        public bool Delete(int id)
        {
            return _SliderRepository.Delete(id);
        }

        public Slider GetByID(int id)
        {
            return _SliderRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Slider Slider)
        {
            return _SliderRepository.Update(Slider);
        }
    }
}