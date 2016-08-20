using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MIS.Models;
using MIS.DataHandler;

namespace MIS.DataHandler.Testing
{
    public class MenuInfoDataHandlerTesting
    {
        public MenuInfoDataHandler db = null;

        public MenuInfoDataHandlerTesting()
        {
            db = new MenuInfoDataHandler();
        }

        [Test]
        public void Add()
        {
            MenuInfo entity = new MenuInfo();
            entity.CreateDateTime = DateTime.Now;
            entity.UpdateDateTime = DateTime.Now;
            entity.MenuName = "菜单名称";
            entity.Grade = 1;
           
            db.Add(entity);
            Console.WriteLine("ID:" + entity.ID);
            Console.WriteLine("插入成功");
        }

        [Test]
        public void Update()
        {
            MenuInfo entity = new MenuInfo();
            entity.ID = 1;
            //entity.UpdateDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entity.MenuName = "菜单111";
            if (db.Update(entity))
                Console.WriteLine("更新完成!!!!");
            else
                Console.WriteLine("更新失败");

        }

        [Test]
        public void Delete()
        {
            if (db.Delete(1))
                Console.WriteLine("删除成功");
            else
                Console.WriteLine("删除失败");
        }

        [Test]
        public void GetList()
        {
            IEnumerable<MenuInfo> list = db.GetList();
            foreach(var item in list)
            {
                Console.WriteLine("ID:{0},Name:{1}",item.ID,item.MenuName);
            }
        }


    }
}
