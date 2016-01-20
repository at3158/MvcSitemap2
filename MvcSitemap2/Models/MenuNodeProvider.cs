using MvcSitemap2.Service;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSitemap2.Models
{
    public class MenuNodeProvider: DynamicNodeProviderBase
    {
        public MenuNodeProvider() : base() { }

        
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            try
            {
                //using (var uow = new MyDBContext())
                using (var menuService = new SmMenuService<SysMenu>(new MyDBContext()))
                {
                    // 取出所有Menu項
                    //var menus = uow.SysMenus.ToList();
                    
                    // 取出所有Menu項
                    var menus = menuService.GetAll().ToList();


                    foreach (var menu in menus)
                    {
                        DynamicNode dynamicNode = new DynamicNode()
                        {
                            Title = menu.Name,
                            ParentKey = menu.ParentId.HasValue ? menu.ParentId.Value.ToString() : "",
                            Key = menu.SysMenuId.ToString(),
                            Action = menu.Action,
                            Controller = menu.Controller,
                            Area = menu.Area,
                            Url = menu.Url,
                            //Roles = roles
                        };

                        if (!string.IsNullOrWhiteSpace(menu.RouteValues))
                        {
                            dynamicNode.RouteValues = menu.RouteValues.Split(',').Select(value => value.Split('='))
                                                .ToDictionary(pair => pair[0], pair => (object)pair[1]);

                        }
                        returnValue.Add(dynamicNode);
                    }
                }

                return returnValue;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}