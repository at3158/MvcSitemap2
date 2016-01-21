using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcSitemap2.Models
{
    public class SmUser 
    {
        [Key]
        [StringLength(300)]
        public String SmUserId { get; set; }

        [Required]
        [StringLength(200)]
        public String Name { get; set; }

        [Required]
        [StringLength(300)]
        public String AdUserId { get; set; }

        [Required]
        public bool IsEnabled { get; set; }
    }
}