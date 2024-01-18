using InterimProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Services
{
    public class MockMenuService : IMenuRepository
    {
        public List<Menu>Menus { get; set; }

        public MockMenuService()
        {
            Menus = new List<Menu>()
            {
                new Menu()
                {
                    ItemId = 1,
                    ItemName = "Fried Chicken",
                    ItemCost = 100,
                    ItemDiscount = 10,
                    CategoryId = 1,

                },

                new Menu()
                {
                    ItemId = 2,
                    ItemName = "Chicken Tikka Pizza",
                    ItemCost = 399,
                    ItemDiscount = 25,
                     CategoryId = 1,

                },

                new Menu()
                {
                    ItemId = 3,
                    ItemName = "Chicken Biryani",
                    ItemCost = 220,
                    ItemDiscount = 20,
                     CategoryId = 1,

                }

            };
        }



        public Menu AddMenu(Menu menu)
        {
            menu.ItemId = Menus.Max(i => i.ItemId)+1;
            Menus.Add(menu);
            return menu;
        }

        public Menu GetMenuById(int id)
        {
            var menu = Menus.SingleOrDefault(i => i.ItemId == id);
            return menu;
                
        }

        public IEnumerable<Menu> GetMenus()
        {
            return Menus;
        }

        public Menu RemoveMenu(int id)
        {
            var menu = Menus.SingleOrDefault(i =>i.ItemId == id);
            if(menu != null)
            {
                Menus.Remove(menu);
            }
            return menu;
        }

        public Menu UpdateMenu(Menu updatedMenu)
        {
            var menu = Menus.SingleOrDefault(i => i.ItemId == updatedMenu.ItemId);
            if(menu != null)
            {
                menu.ItemName = updatedMenu.ItemName;
                menu.ItemCost = updatedMenu.ItemCost;
                menu.ItemDiscount = updatedMenu.ItemDiscount;
               
            }
            return menu;
        }

        public Category GetCategoryByMenuItemId(int id)
        {
            var menu = Menus.SingleOrDefault(m => m.ItemId == id).Category;
            return menu;
        }

        public List<Menu> GetMenusByCategory(int id)
        {
            var menu = Menus.Where(m => m.CategoryId == id).ToList();
            return menu;
        }
    }
}
