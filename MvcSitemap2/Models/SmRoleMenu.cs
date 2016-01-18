﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcSitemap2.Models
{
    public class SmRoleMenu
    {
        [Key]
        [Column(Order = 1)]
        public int SmRoleId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int SmMenuId { get; set; }
    }
}