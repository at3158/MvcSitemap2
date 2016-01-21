using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcSitemap2.Models
{
    public class SmRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SmRoleId { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool IsEnabled { get; set; }
    }
}