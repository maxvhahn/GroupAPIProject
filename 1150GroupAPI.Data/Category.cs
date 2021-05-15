﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey(nameof(CompanyID))]
        public int CompanyID { get; set; }
    }
}
