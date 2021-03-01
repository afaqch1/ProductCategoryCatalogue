using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Dto
{
    public class AddProductDto
    { 
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public int CategoryId { get; set; }

    }
}
