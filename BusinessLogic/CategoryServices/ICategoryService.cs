using BusinessObjectLayer.Dto;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CategoryServices
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(AddCategoryDto addCategory);
        Task<List<Category>> GetCategory();
        Task<Boolean> DeleteCategory(int id);
        Task<Category> UpdateCategory(UpdateCategoryDto updatedcategory);
    }
}
