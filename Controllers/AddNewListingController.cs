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

		private readonly ICategoryRepository _categoryRepository;
		private readonly IToolRepository _toolRepository;
		public AddNewListingController(ICategoryRepository categoryRepository, IToolRepository toolRepository)
		{
			_categoryRepository = categoryRepository;
			_toolRepository = toolRepository;
		}

		public IActionResult Index()
		{
			return View(new AddNewListingViewModel(_categoryRepository.AllCategories, _toolRepository.AllTools));

		}



		//[HttpPost]
  //      public IActionResult AddNewListingPost([FromBody] AddNewListingViewModel model)
  //      {

		//		//if (Photo != null)
		//		//{
		//		//	// If a new photo is uploaded, the existing photo must be
		//		//	// deleted. So check if there is an existing photo and delete
		//		//	if (employee.PhotoPath != null)
		//		//	{
		//		//		string filePath = Path.Combine(webHostEnvironment.WebRootPath,
		//		//			"images", employee.PhotoPath);
		//		//		System.IO.File.Delete(filePath);
		//		//	}
		//		//	// Save the new photo in wwwroot/images folder and update
		//		//	// PhotoPath property of the employee object
		//		//	employee.PhotoPath = ProcessUploadedFile();
		//		//}

		//}

	}

}

 
