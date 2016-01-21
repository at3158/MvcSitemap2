using MvcSitemap2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcSitemap2.Models
{
    public class SmRoleProvider : RoleProvider, IDisposable
    {
        private String _applicationName = "My Application";
        private MyDBContext _dbContext = null;
        private SmUserService<SmUser> _userService = null;
        private SmRoleService<SmRole> _roleService = null;
        private SmUserRoleService<SmUserRole> _userRoleService = null;

        public SmRoleProvider()
        {
            this._dbContext = new MyDBContext();
            this._userService = new SmUserService<SmUser>(this._dbContext);
            this._roleService = new SmRoleService<SmRole>(this._dbContext);
            this._userRoleService = new SmUserRoleService<SmUserRole>(this._dbContext);
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            try
            {
                var userNames = this._userRoleService.Get(
                    x => (x.SmRole.Name == roleName && x.SmUser.AdUserId == usernameToMatch)).ToList().Select(x => x.SmUser.AdUserId);
                if (userNames != null)
                    return userNames.ToArray();
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "FindUsersInRole.");
                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}