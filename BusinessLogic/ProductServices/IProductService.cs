using BuinessObjectLayer.Dto;
using BusinessObjectLayer.Dto;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ProductServices

{
    public interface IProductService
    {
        Task<Product> AddProduct(AddProductDto addproduct);
        Task<List<Product>> GetProduct();
        Task<Product> UpdateProduct(UpdateProductDto updatedproduct);
        Task<Boolean> DeleteProduct(int id);
    }
}
