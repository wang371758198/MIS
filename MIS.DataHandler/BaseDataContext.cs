using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS.Models;

namespace MIS.DataHandler
{
    public  class BaseDataContext : DbContext
    {
        public DbSet<MenuInfo> MenuInfo { get; set; }

    }
}
