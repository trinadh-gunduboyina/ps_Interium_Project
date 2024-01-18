using InterimProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Services
{
    public class MenuService : IMenuRepository
    {

        private readonly InProjectDBContext db;

        public MenuService(InProjectDBContext db)
        {
            this.db = db;   
        }


        public Menu AddMenu(Menu menu)
        {
            this.db.Add(menu);
            this.db.SaveChanges();
            return menu;
        }

        public Menu GetMenuById(int id)
        {
          // return this.db.Menus.Find(id);
          return this.db.Menus.SingleOrDefault(m => m.ItemId == id);
        }

        public IEnumerable<Menu> GetMenus()
        {
            //var menus = from menu in this.db.Menus orderby menu.ItemCost descending select menu;
            return this.db.Menus.ToList();
        }

        public Menu RemoveMenu(int id)
        {
            var menu = GetMenuById(id);
            if (menu != null)
            {
                this.db.Menus.Remove(menu);
                this.db.SaveChanges();
            }
            return menu;
        }

        public Menu UpdateMenu(Menu menu)
        {
            var entity = this.db.Menus.Attach(menu);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.db.SaveChanges();
            return menu;
        }

        public Category GetCategoryByMenuItemId(int id)
        {
            return this.db.Menus.SingleOrDefault(m => m.ItemId == id).Category;
        }

        public List<Menu> GetMenusByCategory(int id)
        {
            return this.db.Menus.Where(m => m.CategoryId == id).ToList();
        }
    }
}
