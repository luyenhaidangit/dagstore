using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Model.Models;
using System.Collections.Generic;

namespace DAGStore.Service
{
    public interface IMenuItemRecordService
    {
        bool Add(MenuItemRecord menuRecord);

        bool Update(MenuItemRecord menuRecord);

        bool Delete(int id);

        IEnumerable<MenuItemRecord> GetAll();

        IEnumerable<MenuItemRecord> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<MenuItemRecord> GetAllByMenuRecord(string menuRecord, int pageIndex, int pageSize, out int totalRow);

        MenuItemRecord GetByID(int id);

        IEnumerable<MenuItemRecord> GetByParentMenuItemRecordID(int id);

        void SaveChanges();
    }

    public class MenuItemRecordService : IMenuItemRecordService
    {
        private IMenuItemRecordRepository _menuItemRecordRepository;
        private IUnitOfWork _unitOfWork;

        public MenuItemRecordService(IMenuItemRecordRepository menuItemRecordRepository, IUnitOfWork unitOfWork)
        {
            this._menuItemRecordRepository = menuItemRecordRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(MenuItemRecord menuItemRecord)
        {
            return _menuItemRecordRepository.Add(menuItemRecord);
        }

        public bool Delete(int id)
        {
            return _menuItemRecordRepository.Delete(id);
        }

        public IEnumerable<MenuItemRecord> GetAll()
        {
            return _menuItemRecordRepository.GetAll();
        }

        public IEnumerable<MenuItemRecord> GetAllByMenuRecord(string menuRecord, int pageIndex, int pageSize, out int totalRow)
        {
            return _menuItemRecordRepository.GetAllByMenuRecord(menuRecord, pageIndex, pageSize, out totalRow);
        }

        public IEnumerable<MenuItemRecord> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _menuItemRecordRepository.GetMultiPaging(x => x.Published, out totalRow, page, pageSize);
        }

        public MenuItemRecord GetByID(int id)
        {
            return _menuItemRecordRepository.GetSingleByID(id);
        }

        public IEnumerable<MenuItemRecord> GetByParentMenuItemRecordID(int id)
        {
            return _menuItemRecordRepository.GetMulti(x => x.Published && x.ParentMenuItemRecordID == id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(MenuItemRecord menuItemRecord)
        {
            return _menuItemRecordRepository.Update(menuItemRecord);
        }
    }
}