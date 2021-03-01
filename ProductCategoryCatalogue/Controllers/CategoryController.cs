using BuinessObjectLayer.Dto;
using BusinessLogic.CategoryServices;
using BusinessObjectLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategoryCatalogue.Controllers
{
    [Route("api/category/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _category = new BusinessLogic.CategoryServices.CategoryService();

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDto addCategory)
        {
            return Ok(await _category.AddCategory(addCategory));
        }

        [Route("all")]
        [HttpGet]
        public async Task<List<CategoryViewDto>> GetCategory()
        {
            List<CategoryViewDto> categoryList = new List<CategoryViewDto>();
            var cat = await _category.GetCategory();
            if (cat.Count > 0)
            {
                foreach (var categories in cat)
                {
                    CategoryViewDto newcategory = new CategoryViewDto
                    {
                        CategoryName = categories.CategoryName,
                        Id=categories.Id
                    };
                    categoryList.Add(newcategory);
                }
            }
            return categoryList;
        }

        [HttpDelete("{id}")]
        public async Task<Boolean> DeleteCategory(int id)
        {
            bool res = await _category.DeleteCategory(id);
            return res;

        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updatedcategory)
        {
            return Ok(await _category.UpdateCategory(updatedcategory));
        }
    }
}
