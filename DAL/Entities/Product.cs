using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public virtual Category category { get; set; }
        public int? CategoryId { get; set; }
    }
}
