using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;

namespace DAGStore.Service
{
    public interface IMenuRecordService
    {
        bool Add(MenuRecord menuRecord);

        bool Update(MenuRecord menuRecord);

        bool Delete(int id);

        IEnumerable<MenuRecord> GetAll();

        IEnumerable<MenuRecord> GetAllPaging(int page, int pageSize, out int totalRow);

        MenuRecord GetByID(int id);

        void SaveChanges();
    }

    public class MenuRecordService : IMenuRecordService
    {
        private IMenuRecordRepository _menuRecordRepository;
        private IUnitOfWork _unitOfWork;

        public MenuRecordService(IMenuRecordRepository menuRecordRepository, IUnitOfWork unitOfWork)
        {
            this._menuRecordRepository = menuRecordRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(MenuRecord menuRecord)
        {
            return _menuRecordRepository.Add(menuRecord);
        }

        public bool Delete(int id)
        {
            return _menuRecordRepository.Delete(id);
        }

        public IEnumerable<MenuRecord> GetAll()
        {
            return _menuRecordRepository.GetAll();
        }

        public IEnumerable<MenuRecord> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _menuRecordRepository.GetMultiPaging(x => x.Published, out totalRow, page, pageSize);
        }

        public MenuRecord GetByID(int id)
        {
            return _menuRecordRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(MenuRecord menuRecord)
        {
            return _menuRecordRepository.Update(menuRecord);
        }
    }
}