using BuinessObjectLayer.Dto;
using BusinessObjectLayer.Dto;
using DAL.DataContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ProductServices
{
    public class ProductService : IProductService
    {
        public async Task<Product> AddProduct(AddProductDto addproduct)
        {
            Product pro = new Product
            {
                ProductName = addproduct.ProductName,
                ProductDetail = addproduct.ProductDetail,
                CategoryId=addproduct.CategoryId
            };
            using(var context=new DataBaseContext())
            {
                await context.Products.AddAsync(pro);
                await context.SaveChangesAsync();
            }
            return pro; 
        }

        public async Task<Boolean> DeleteProduct(int id)
        {
            Product product = new Product();
            using (var context = new DataBaseContext())
            {
                product = await context.Products.FirstOrDefaultAsync(s => s.Id == id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async  Task<List<Product>> GetProduct()
        {
            List<Product> pro = new List<Product>();
            using(var context=new DataBaseContext())
            {
                pro = await context.Products.ToListAsync();
            }
            return pro;
        }

        public async Task<Product> UpdateProduct(UpdateProductDto updatedproduct)
        {
            using (var context = new DataBaseContext())
            {
                Product product = await context.Products.FirstOrDefaultAsync(s => s.Id == updatedproduct.Id);
                product.ProductName = updatedproduct.ProductName;
                product.ProductDetail = updatedproduct.ProductDetail;
                product.CategoryId = updatedproduct.CategoryId;

                context.Products.Update(product);
                await context.SaveChangesAsync();
                return product;
            }
        }
    }
}
