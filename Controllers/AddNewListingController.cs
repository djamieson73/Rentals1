using Entities.Models;
using Entities.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;

namespace WebApplication9.Controllers
{
	public class AddNewListingController : Controller
	{

		//This controller adds a new tool listing to the ToolList database

		private readonly ICategoryRepository _categoryRepository;
		private readonly IToolListRepository _toolListRepository;
        private readonly IToolRepository _toolRepository;
        public AddNewListingController(ICategoryRepository categoryRepository, IToolListRepository toollistRepository, IToolRepository toolRepository)
		{
			_categoryRepository = categoryRepository;
			_toolListRepository = toollistRepository;
            _toolRepository = toolRepository;
        }

		public IActionResult Index()
		{
			return View(new AddNewListingViewModel(_categoryRepository.AllCategories, new List<Tool>()));

		}


        [HttpPost]
        public IActionResult FormsTestPost([FromForm] AddNewListingViewModel model) //FromBody is for APIs
        {
            if (ModelState.IsValid == false)
            {
                model.AllCategories= _categoryRepository.AllCategories;
                model.AllTools= _toolRepository.AllTools;
                return View("~/Views/AddNewListing/index.cshtml", model);
            }

            var entity = new ToolList();

            entity.Description = model?.Description;
            entity.Price = model?.Price ?? 0; // if price = null, default to 0; 'null coalescing operator'
            entity.ToolId = model.ToolId;
            entity.DateIn = DateTime.UtcNow;
            entity.UserId = "999";

            _toolListRepository.SaveToolList(entity);
            return RedirectToAction("Index", "Category");

        }


        [HttpGet]
        public IActionResult GetToolList(int CatId)
        {
            var tools = _toolRepository.AllTools.Where(m => m.CatId == CatId);

            return Ok(tools);

        }


    }

}

 
