using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace MIS.Models
{
    [Table("MenuInfo",Schema ="dbo")]
    public class MenuInfo
    {

        /// <summary>
        /// ID
        /// </summary>		
        public int ID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>		
        public string MenuName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
       [JsonProperty( PropertyName = "_parentId")]
        public int? ParentMenuID { get; set; }
        /// <summary>
        /// Uri
        /// </summary>		
        public string Uri { get; set; }
        /// <summary>
        /// 排序 从小到大
        /// </summary>		
        public int Grade { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// 图标
        /// </summary>		
        public string Icon { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>		
        public DateTime UpdateDateTime { get; set; }

    }
}
