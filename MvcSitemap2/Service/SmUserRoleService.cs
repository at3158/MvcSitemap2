using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using MvcSitemap2.Models;
using System;

namespace MvcSitemap2.Service
{
    public class SmUserRoleService<T> : IDisposable where T : SmUserRole
    {
        private MyDBContext _dbContext = new MyDBContext();
        public IQueryable<SmUserRole> GetAll()
        {
            return this._dbContext.SmUserRoles.AsQueryable();
        }

        public IQueryable<SmUserRole> Get(Func<SmUserRole, bool> filter)
        {
            var entities = this._dbContext.SmUserRoles.Where(filter).AsQueryable();
            return entities;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}