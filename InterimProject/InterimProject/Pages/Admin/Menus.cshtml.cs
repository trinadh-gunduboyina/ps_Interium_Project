using InterimProject.Models;
using InterimProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterimProject.Pages.Admin
{
    [Authorize]
    public class MenusModel : PageModel
    {
        private readonly IMenuRepository menuRepository;


        private readonly ICategoryRepository categoryRepository;
        public MenusModel(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //public Category currentCategory { get; set; }
        public IEnumerable<Menu> Menus { get; set;}

        public List<Category> Categories { get; set; }

        [BindProperty]
        public int Number { get; set; }

        //public MenusModel(IMenuRepository menuRepository)
        //{
        //    this.menuRepository = menuRepository;
          
        //}

        public void OnGet()
        {
            //Menus = this.menuRepository.GetMenus();

            Menus = this.categoryRepository.GetMenus();
            Categories = this.categoryRepository.GetAllCategories();
            //currentCategory = Categories[0];

        }


        public void OnPost()
        {
            
            Categories = this.categoryRepository.GetAllCategories();

            Menus = this.categoryRepository.GetMenusByCategory(Number);
        }
    }
}
