using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterimProject.Models;
using InterimProject.Services;

namespace InterimProject.Pages.Admin
{
    public class SaveModel : PageModel
    {
        private readonly IMenuRepository menuRepository;

        private readonly ICategoryRepository categoryRepository;

        private readonly IHostEnvironment hostEnviroment;

        public SaveModel(IMenuRepository menuRepository,IHostEnvironment hostEnvironment, ICategoryRepository categoryRepository)
        {
            this.menuRepository = menuRepository;
            this.hostEnviroment = hostEnvironment;
            this.categoryRepository = categoryRepository;
        }

        public List<Menu> Menus { get; set; }

        public List<Category> Categories { get; set; }

        [BindProperty]
        public Menu Menu { get; set; }

        [BindProperty]
        public int Number { get; set; }

        

        public IActionResult OnGet(int? id)
        {
            Categories = this.categoryRepository.GetAllCategories();
            if(id.HasValue)
            {
                Menu = this.menuRepository.GetMenuById(id.Value);
                Menus = (List<Menu>)this.menuRepository.GetMenus();
                
            }
            else
            {
                Menu = new Menu();
            }
            

            if(Menu == null)
            {
                return RedirectToPage("/NotFound"); 
            }
            return Page();

        }

        public IActionResult OnPost()
        {
            Categories = this.categoryRepository.GetAllCategories();

           
                if(Menu.ItemId > 0)
                {
                    this.menuRepository.UpdateMenu(Menu);
                    TempData["Message"] = "Data Updated Successfully";
                }
                else
                {   
                    this.menuRepository.AddMenu(Menu);
                    TempData["Message"] = "Data Added Successfully";
                }
           // var menu = this.menuRepository.UpdateMenu(Menu);
            return RedirectToPage("/Admin/Details", new {id=Menu.ItemId });
        }

       
    }
}
