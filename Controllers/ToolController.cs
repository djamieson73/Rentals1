using Entities.Models;
using Entities.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebApplication9.Controllers
{
    public class ToolController : Controller
    {
        //This controller displays the tools for a specified category

        private readonly IToolRepository _toolRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ToolController(IToolRepository toolRepository, ICategoryRepository categoryRepository)
        {
            _toolRepository = toolRepository;
            _categoryRepository = categoryRepository;
        }


        public IActionResult Index(string Id)
        {
            IEnumerable<Tool> Tools;
            Tools = _toolRepository.AllTools.Where(p => p.CatId == Convert.ToInt32(Id)).OrderBy(p => p.ToolName);

            string? CatName;
            CatName = _categoryRepository.AllCategories.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.CatName;

            return View(new ToolViewModel(Tools, CatName));

        }

    }
}
