﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuinessObjectLayer.Dto
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public int CategoryId { get; set; }
    }
}
