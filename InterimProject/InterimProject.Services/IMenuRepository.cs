using InterimProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Services
{
    public interface IMenuRepository
    {
        //CRUD Operations
        Menu AddMenu(Menu menu);
        Menu UpdateMenu(Menu menu);

        Menu RemoveMenu(int id);

        IEnumerable<Menu> GetMenus();
        Menu GetMenuById(int id);


       
        public List<Menu> GetMenusByCategory(int id);
        public Category GetCategoryByMenuItemId(int id);

       
        

    }
}
