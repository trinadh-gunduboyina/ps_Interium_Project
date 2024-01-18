using InterimProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Services
{
    public class CategoryService : ICategoryRepository
    {

        private readonly InProjectDBContext db;

        public CategoryService(InProjectDBContext db)
        {
            this.db = db;   
        }

        public Category AddCategory(Category newCategory)
        {
            this.db.Add(newCategory);
            this.db.SaveChanges();

            return newCategory;
        }

        public List<Category> GetAllCategories()
        {
            return this.db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category GetCategoryByMenuItemId(int id)
        {
            return this.db.Menus.SingleOrDefault(f => f.CategoryId == id).Category;
        }

        public List<Menu> GetMenus()
        {
            return this.db.Menus.ToList();
        }

        public List<Menu> GetMenusByCategory(int id)
        {
            var menus = this.db.Menus.Where(f => f.CategoryId == id).ToList();
            return menus;
        }

        public Category RemoveCategory(int id)
        {
            var category = this.GetCategoryById(id);
            if (category != null)
            {
                this.db.Categories.Remove(category);
                this.db.SaveChanges();
            }

            return category;
        }

        public Category UpdateCategory(Category updatedCategory)
        {
            this.db.Categories.Update(updatedCategory);
            this.db.SaveChanges();

            return updatedCategory;
        }
    }
}
