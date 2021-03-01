using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DAL.Entities;
using BusinessLogic.ProductServices;
using BuinessObjectLayer.Dto;
using BusinessObjectLayer.Dto;

namespace ProductCategoryCatalogue.Controllers
{
    [Route("api/product/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _product = new BusinessLogic.ProductServices.ProductService();

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto addProduct)
        {
            return Ok(await _product.AddProduct(addProduct));
        }

        [Route("all")]
        [HttpGet] 
        public async Task<List<ProductViewDto>> GetProduct()
        {
            List<ProductViewDto> proList = new List<ProductViewDto>();
            
          
            var pro = await _product.GetProduct();
            if (pro.Count > 0)
            {
                foreach (var product in pro)
                {
                    ProductViewDto newproduct = new ProductViewDto
                    {
                        ProductName = product.ProductName,
                        ProductDetail = product.ProductDetail,
                        Id = product.Id,
                        CategoryId = (int)product.CategoryId
                        


                };
                    proList.Add(newproduct);
                }
            }
            return proList;
        }

        [HttpDelete("{id}")]
        public async Task<Boolean> DeleteProduct(int id)
        {
            bool res = await _product.DeleteProduct(id);
            return res;
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updatedproduct)
        {
            return Ok(await _product.UpdateProduct(updatedproduct));
        }

    }
}
