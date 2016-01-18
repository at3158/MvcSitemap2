using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcSitemap2.Models
{
    public class SysRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SysRoleId { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}