using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS.Models;
using System.Data.Entity;

namespace MIS.DataHandler
{
    public class MenuInfoDataHandler 
    {
        public static BaseDataContext _context = null;
        public MenuInfoDataHandler()
        {
            _context = new BaseDataContext();
        }

        public bool Add(MenuInfo entity)
        {
            if (entity == null)
            {
                return false;
            }
            entity.CreateDateTime = DateTime.Now;
            entity.UpdateDateTime = DateTime.Now;
            _context.MenuInfo.Add(entity);
            return _context.SaveChanges() > 0;

        }

        public bool Update(MenuInfo entity)
        {
            if (entity == null)
                return false;
            MenuInfo update = _context.MenuInfo.Find(entity.ID);
            update.MenuName = entity.MenuName;
            update.ParentMenuID = entity.ParentMenuID;
            update.Uri = entity.Uri;
            update.Remark = entity.Remark;
            update.Icon = entity.Icon;
            update.Grade = entity.Grade;
            update.UpdateDateTime = DateTime.Now;
            return _context.SaveChanges() > 0;
        }


        public bool Delete(int? id)
        {
            if (id.HasValue)
            {
                MenuInfo entity = _context.MenuInfo.Find(id.Value);
                _context.MenuInfo.Remove(entity);
                return _context.SaveChanges() > 0;
            }
            else
                return false;
        }


        public IEnumerable<MenuInfo> GetList()
        {
            return _context.MenuInfo.SqlQuery(" SELECT * FROM dbo.MenuInfo ").ToList();
        }


    }
}
