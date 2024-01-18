using InterimProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Services
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategories();
        public List<Menu> GetMenus();
        public List<Menu> GetMenusByCategory(int id);
        public Category GetCategoryByMenuItemId(int id);
        public Category GetCategoryById(int id);

        public Category AddCategory(Category newCategory);
        public Category UpdateCategory(Category updatedCategory);
        public Category RemoveCategory(int id);

    }
}
