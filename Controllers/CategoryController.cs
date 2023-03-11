using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Entities.Models;

namespace WebApplication9
{
	public class CategoryController : Controller
	{

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
			_categoryRepository = categoryRepository; 
		}
		
      
        public IActionResult Index()
		{
             return View(_categoryRepository.AllCategories);
		}




public PartialViewResult DoPartial(int id)
		{
            if (id == 0)
            {
                return PartialView("_CategoryPartial");
            }
            else if (id == 1)
			{
                return PartialView("_OutdoorPartial");
            }
			else if (id == 2)
            {
                return PartialView("_PowerPartial");
            }
            return PartialView("_IndoorPartial");

        }















	}
}
