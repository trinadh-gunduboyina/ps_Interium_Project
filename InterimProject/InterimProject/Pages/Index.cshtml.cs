using InterimProject.Models;
using InterimProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterimProject.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        public IndexModel(IFrontPageRepository frontPageRepository)
        {
            FrontPageRepository = frontPageRepository;
        }

        public IFrontPageRepository FrontPageRepository { get; }

        public FrontPageData data;

        public void OnGet()
        {
            data = FrontPageRepository.GetFrontPageData();
           

        }
    }
}