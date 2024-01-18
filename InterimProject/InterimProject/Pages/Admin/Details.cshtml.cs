using InterimProject.Services;
using InterimProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace InterimProject.Pages.Admin
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IMenuRepository menuRepository;

        public DetailsModel(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public Menu Menu { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int id)
        {
            try
            {
                Menu = this.menuRepository.GetMenuById(id);

                if (Menu == null)
                    return RedirectToPage("/NotFound");
            }
            catch (Exception ex)
            {
                if (Menu == null)
                    return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
