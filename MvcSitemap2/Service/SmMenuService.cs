using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using MvcSitemap2.Models;

namespace MvcSitemap2.Service
{
    public class SmMenuService<T> : IDisposable where T : SysMenu
    {
        private MyDBContext _dbContext = new MyDBContext();

        public IQueryable<SysMenu> GetAll()
        {
            return this._dbContext.SysMenus.AsQueryable();
        }

        public IQueryable<SysMenu> Get(Func<SysMenu, bool> filter)
        {
            var entities = this._dbContext.SysMenus.Where(filter).AsQueryable();
            return entities;
        }

        public void Dispose()
        {
        }
    }
}