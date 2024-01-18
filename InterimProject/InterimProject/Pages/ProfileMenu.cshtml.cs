using InterimProject.Services;
using InterimProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterimProject.Pages
{
    public class ProfileMenuModel : PageModel
    {
        private readonly IMenuRepository menuRepository;

        public IEnumerable<Menu> Menus { get; set; }    

        public ProfileMenuModel(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public void OnGet()
        {
            Menus = this.menuRepository.GetMenus();

        }
    }
}
