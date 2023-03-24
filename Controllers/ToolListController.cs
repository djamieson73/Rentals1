using Entities.Models.ViewModels;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;


namespace WebApplication9.Controllers
{
    public class ToolListController : Controller
    {

        // This controller displays a list of specified tools for rent, with a sort feature

        private readonly IToolListRepository _toolListRepository;
        private readonly IToolRepository _toolRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ToolListController(IToolListRepository toollistRepository, IToolRepository toolRepository, ICategoryRepository categoryRepository)
        {
            _toolListRepository = toollistRepository;
            _toolRepository = toolRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(int Id)
        {

            IEnumerable<ToolList> ToolList;
            ToolList = _toolListRepository.ToolList.Where(p => p.ToolId == Convert.ToInt32(Id)).OrderBy(p => p.DateIn);

            string? CurrentToolCategory;
            CurrentToolCategory = _toolRepository.AllTools.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.ToolName;

            int? CategoryId;
            CategoryId = _toolRepository.AllTools.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.CatId;

            int? CurrentCategory;
            CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.Id;

            string? CategoryColor;
            CategoryColor = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.Color;


            string? CategoryColorBg;
            CategoryColorBg = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.ColorBg;


            string? ToolDescription;
            ToolDescription = _toolListRepository.ToolList.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.Description;

            return View(new ToolListViewModel(ToolList, CurrentToolCategory, CategoryId, CurrentCategory, CategoryColor, CategoryColorBg, ToolDescription, Id));


        }

        public IActionResult RefreshToolList(int Id, string priceorderby)
        {


            IEnumerable<ToolList> ToolList;
            switch (priceorderby)
            {
                case "HtoL":
                    ToolList = _toolListRepository.ToolList.Where(p => p.ToolId == Convert.ToInt32(Id)).OrderByDescending(p => p.Price);
                    break;
                case "LtoH":
                    ToolList = _toolListRepository.ToolList.Where(p => p.ToolId == Convert.ToInt32(Id)).OrderBy(p => p.Price);
                    break;
                default:
                    ToolList = _toolListRepository.ToolList.Where(p => p.ToolId == Convert.ToInt32(Id)).OrderBy(p => p.Price);
                    break;

            }

            string? CurrentToolCategory;
            CurrentToolCategory = _toolRepository.AllTools.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.ToolName;

            int? CategoryId;
            CategoryId = _toolRepository.AllTools.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.CatId;

            int? CurrentCategory;
            CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.Id;

            string? CategoryColor;
            CategoryColor = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.Color;


            string? CategoryColorBg;
            CategoryColorBg = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.ColorBg;

            string? ToolDescription;
            ToolDescription = _toolListRepository.ToolList.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.Description;

            return PartialView("_ToolListCard", new ToolListViewModel(ToolList, CurrentToolCategory, CategoryId, CurrentCategory, CategoryColor, CategoryColorBg, ToolDescription, Id));


        }

    }
}
