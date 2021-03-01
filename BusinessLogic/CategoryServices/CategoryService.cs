using BusinessObjectLayer.Dto;
using DAL.DataContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        public async Task<Category> AddCategory(AddCategoryDto addCategory)
        {
            Category cat = new Category
            {
                CategoryName = addCategory.CategoryName
            };
            using(var context= new DataBaseContext())
            {
                await context.Categories.AddAsync(cat);
                await context.SaveChangesAsync();
            }
            return cat;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Category category = new Category();
            using (var context = new DataBaseContext())
            {
                category = await context.Categories.FirstOrDefaultAsync(s => s.Id == id);
                if (category != null)
                {
                    context.Categories.Remove(category);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task<List<Category>> GetCategory()
        {
            List<Category> cat = new List<Category>();
            using (var context = new DataBaseContext())
            {
               cat= await context.Categories.ToListAsync();
               
            }
            return cat;

        }

        public async Task<Category> UpdateCategory(UpdateCategoryDto updatedcategory)
        {
            using (var context = new DataBaseContext())
            {
                Category category = await context.Categories.FirstOrDefaultAsync(s => s.Id == updatedcategory.Id);
                category.CategoryName = updatedcategory.CategoryName;
                context.Categories.Update(category);
                await context.SaveChangesAsync();
                return category;
            }
        }
    }
}
