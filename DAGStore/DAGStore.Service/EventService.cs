using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface IEventService
    {
        IEnumerable<Event> GetAll();

        Event GetByID(int id);

        bool Add(Event Event);

        bool Update(Event Event);

        bool Delete(int id);

        void SaveChanges();
    }

    public class EventService : IEventService
    {
        private IEventRepository _EventRepository;
        private IUnitOfWork _unitOfWork;

        public EventService(IEventRepository EventRepository, IUnitOfWork unitOfWork)
        {
            this._EventRepository = EventRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Event> GetAll()
        {
            return _EventRepository.GetAll().ToList();
        }


        public bool Add(Event Event)
        {
            return _EventRepository.Add(Event);
        }

        public bool Delete(int id)
        {
            return _EventRepository.Delete(id);
        }

        public Event GetByID(int id)
        {
            return _EventRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Event Event)
        {
            return _EventRepository.Update(Event);
        }
    }
}