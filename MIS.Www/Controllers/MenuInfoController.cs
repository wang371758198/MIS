using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIS.Models;
using MIS.DataHandler;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace MIS.Www.Controllers
{
    public class MenuInfoController : Controller
    {
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
           // MenuInfoDataHandler handler = new MenuInfoDataHandler();
           // IEnumerable<MenuInfo> list = handler.GetList();
            return View();
        }

        /// <summary>
        /// 菜单编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(MenuInfo model)
        {
            MenuInfoDataHandler handler = new MenuInfoDataHandler();
            
            JObject result = new JObject();
            if (model?.ID == 0)
            {
                if (handler.Add(model))
                {
                    result.Add("Status", 1);
                    result.Add("Msg", "添加成功");
                }
                else
                {
                    result.Add("Status",0);
                    result.Add("Msg","添加失败");
                }
            }
            else
            {
               
                if (handler.Update(model))
                {
                    result.Add("Status", 1);
                    result.Add("Msg", "添加成功");
                }
                else
                {
                    result.Add("Status", 0);
                    result.Add("Msg", "添加失败");
                }
            }
            return Json(result.ToString());
        }

        public ActionResult GetEntity(MenuInfo model)
        {
            MenuInfoDataHandler handler = new MenuInfoDataHandler();
            ViewBag.ParentMenuInfos = handler.GetList().Select(o => new MenuInfo
            {
                ID = o.ID,
                MenuName = o.MenuName
            });
            if (model == null)
            {
                model = new MenuInfo();
            }
            return View("Edit",model);
        }

        public ActionResult GetList()
        {
            MenuInfoDataHandler handler = new MenuInfoDataHandler();
            IEnumerable<MenuInfo> list = handler.GetList();
            JObject result = new JObject();
            result.Add("total",list.Count());
           
            result.Add("rows", JToken.Parse(JsonConvert.SerializeObject(list)));
            return Content(result.ToString());
        }


        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                MenuInfoDataHandler handler = new MenuInfoDataHandler();
                if (handler.Delete(id))
                {
                    return Json(1);
                }
                else
                    return Json(0);
            }
            return Json(0);
        }

    }
}