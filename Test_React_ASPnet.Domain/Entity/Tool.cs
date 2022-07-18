﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_React_ASPnet.Domain.Entity
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
