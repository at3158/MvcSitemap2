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
    public class SmUserService<T> :  IDisposable where T : SmUser
    {
        private MyDBContext _dbContext = new MyDBContext();

        public IQueryable<SmUser> GetAll()
        {
            return this._dbContext.SmUsers.AsQueryable();
        }

        public IQueryable<SmUser> Get(Func<SmUser, bool> filter)
        {
            var entities = this._dbContext.SmUsers.Where(filter).AsQueryable();
            return entities;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}