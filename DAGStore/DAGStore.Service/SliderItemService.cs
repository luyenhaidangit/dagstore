using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface ISliderItemService
    {
        bool Add(SliderItem SliderItem);

        bool Update(SliderItem SliderItem);

        bool Delete(int id);

        IEnumerable<SliderItem> GetAll();

        SliderItem GetByID(int id);

        void SaveChanges();
    }

    public class SliderItemService : ISliderItemService
    {
        private ISliderItemRepository _SliderItemRepository;
        private IUnitOfWork _unitOfWork;

        public SliderItemService(ISliderItemRepository SliderItemRepository, IUnitOfWork unitOfWork)
        {
            this._SliderItemRepository = SliderItemRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<SliderItem> GetAll()
        {
            return _SliderItemRepository.GetAll();
        }


        public bool Add(SliderItem SliderItem)
        {
            return _SliderItemRepository.Add(SliderItem);
        }

        public bool Delete(int id)
        {
            return _SliderItemRepository.Delete(id);
        }

        public SliderItem GetByID(int id)
        {
            return _SliderItemRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(SliderItem SliderItem)
        {
            return _SliderItemRepository.Update(SliderItem);
        }
    }
}