﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDNVNONE.Entities;

namespace CDNVNONE.Data
{
    public class Person:Entity<int>
    {
        public string Name { get; set; }
    }
}
