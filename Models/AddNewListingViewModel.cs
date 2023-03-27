using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModels
{
    public class AddNewListingViewModel
    {

		[BindProperty]
		public IFormFile? Photo { get; set; }

		public int? Price { get; set; }

        public string? Description { get; set; }

        [ValidateNever]
        public IEnumerable<Category> AllCategories { get; set;  }

        [ValidateNever]
        public IEnumerable<Tool> AllTools { get; set;  }

        public int CatId { get; set; }
        public int ToolId { get; set; }

        public AddNewListingViewModel()
        {

        }

        public AddNewListingViewModel(IEnumerable<Category> allCategories1, IEnumerable<Tool> allTools1)
        {
            AllCategories = allCategories1;
            AllTools = allTools1;
        }


    }
}
