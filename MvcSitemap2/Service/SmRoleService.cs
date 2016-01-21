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
    public class SmRoleService<T> : IDisposable where T : SmRole
    {
        private MyDBContext _dbContext = new MyDBContext();

        public SmRoleService(MyDBContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public IQueryable<SmRole> GetAll()
        {
            return this._dbContext.SmRoles.AsQueryable();
        }

        public IQueryable<SmRole> Get(Func<SmRole, bool> filter)
        {
            var entities = this._dbContext.SmRoles.Where(filter).AsQueryable();
            return entities;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}