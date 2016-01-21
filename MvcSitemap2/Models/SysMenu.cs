using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcSitemap2.Models
{
    public class SysMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SysMenuId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string NameCn { get; set; }
        [Required]
        [StringLength(200)]
        public string NameUs { get; set; }
        [StringLength(200)]
        public string Area { get; set; }
        [StringLength(200)]
        public string Controller { get; set; }
        [StringLength(200)]
        public string Action { get; set; }
        public string Url { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public string RouteValues { get; set; }
        public int? OrderSn { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class MyDBContext : DbContext
    {
        public DbSet<SysMenu> SysMenus { get; set; }

        public System.Data.Entity.DbSet<MvcSitemap2.Models.SmRoleMenu> SmRoleMenus { get; set; }

        public System.Data.Entity.DbSet<MvcSitemap2.Models.SysRole> SysRoles { get; set; }

        public System.Data.Entity.DbSet<MvcSitemap2.Models.SmRole> SmRoles { get; set; }

        public System.Data.Entity.DbSet<MvcSitemap2.Models.SmUserRole> SmUserRoles { get; set; }

        public System.Data.Entity.DbSet<MvcSitemap2.Models.SmUser> SmUsers { get; set; }
    }
 }