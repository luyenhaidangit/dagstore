using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Service
{
    public interface ITagService
    {
        bool Add(Tag Tag);

        bool Update(Tag Tag);

        bool Delete(int id);

        IEnumerable<Tag> GetAll();

        Tag GetByID(int id);

        void SaveChanges();
    }

    public class TagService : ITagService
    {
        private ITagRepository _TagRepository;
        private IUnitOfWork _unitOfWork;

        public TagService(ITagRepository TagRepository, IUnitOfWork unitOfWork)
        {
            this._TagRepository = TagRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Tag> GetAll()
        {
            return _TagRepository.GetAll();
        }


        public bool Add(Tag Tag)
        {
            return _TagRepository.Add(Tag);
        }

        public bool Delete(int id)
        {
            return _TagRepository.Delete(id);
        }

        public Tag GetByID(int id)
        {
            return _TagRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(Tag Tag)
        {
            return _TagRepository.Update(Tag);
        }
    }
}