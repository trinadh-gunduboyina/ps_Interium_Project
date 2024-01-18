using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterimProject.Models;
using InterimProject.Services;
using Microsoft.AspNetCore.Authorization;

namespace InterimProject.Pages.Admin
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IMenuRepository menuRepository;

        public DeleteModel(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public Menu Menu { get; set; }

        public IActionResult OnGet(int id)
        {
            Menu = this.menuRepository.GetMenuById(id);

            if (Menu == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Menu = this.menuRepository.RemoveMenu(id);

            if (Menu == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("/Admin/Menus");
        }
    }
}
