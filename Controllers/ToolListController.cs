using Entities.Models.ViewModels;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using static Humanizer.In;

namespace WebApplication9.Controllers
{
    public class ToolListController : Controller
    {



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

            //IEnumerable<ToolList> ToolList;
            //ViewData["PriceOrder"] = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            //switch (sortOrder)
            //{
            //    case "price_desc":
            //        ToolList = _toolListRepository.ToolList.Where(p => p.ToolId == Convert.ToInt32(Id)).OrderBy(p => p.Price);
            //        break;
            //    default:
            //        ToolList = _toolListRepository.ToolList.Where(p => p.ToolId == Convert.ToInt32(Id)).OrderBy(p => p.DateIn);
            //        break;
            //}


            IEnumerable<ToolList> ToolList;
            ToolList = _toolListRepository.ToolList.Where(p => p.ToolId == Convert.ToInt32(Id)).OrderBy(p => p.DateIn);

            string? CurrentToolCategory;
            CurrentToolCategory = _toolRepository.AllTools.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.ToolName;

            int? CategoryId;
            CategoryId = _toolRepository.AllTools.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.CatId;

            int? CurrentCategory;
            CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.Id;

            string? CategoryColor;
            //CategoryColor = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.Color;
            CategoryColor = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.Color;


            string? CategoryColorBg;
            //CategoryColor = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.Color;
            CategoryColorBg = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.ColorBg;


            // return View(_categoryRepository.AllCategories);
            //return View(toollist);


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
            //CategoryColor = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.Color;
            CategoryColor = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.Color;


            string? CategoryColorBg;
            //CategoryColor = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.Color;
            CategoryColorBg = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == CategoryId)?.ColorBg;

            string? ToolDescription;
            ToolDescription = _toolListRepository.ToolList.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.Description;

            return PartialView("_ToolListCard", new ToolListViewModel(ToolList, CurrentToolCategory, CategoryId, CurrentCategory, CategoryColor, CategoryColorBg, ToolDescription, Id));


        }





















        //private readonly IToolRepository _toolRepository;
        //private readonly IToolListRepository _toolListRepository;
        //public ToolListController(IToolRepository toolRepository, ToolListRepository toolListRepository)
        //{
        //    _toolRepository = toolRepository;
        //    _toolListRepository = toolListRepository;
        //}


        //public IActionResult Index(string Id)
        //    public IActionResult Index()
        //{

        //IEnumerable<ToolList> tools;
        //tools = _toolListRepository.ToolList.Where(p => p.ToolId == Convert.ToInt32(Id)).OrderBy(p => p.DateIn);

        //string? ToolCategory;
        //ToolCategory = _toolRepository.AllTools.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.ToolName;


        //return View(new ToolListViewModel(tools, ToolCategory));

        //return View();
        //}

        //private IActionResult View()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
