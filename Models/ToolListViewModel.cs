using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModels
{
    public class ToolListViewModel
    {



        public IEnumerable<ToolList> ToolList { get; }

        public string? CurrentToolCategory { get; }

        public int? CategoryId { get;  }

        public int? CurrentCategory { get; }

        public string? CategoryColor { get; }

        public string? CategoryColorBg { get; }

        public string? ToolDescription { get; }

        public List<SelectListItem> DdlOrderByPrice { get; private set; }

        public int ToolListID { get; set; }


        public ToolListViewModel(IEnumerable<ToolList> toolList1, string? currentToolCategory1, int? categoryId1, int? currentCategory1, string? categoryColor1, string? categoryColorBg1, string? toolDescription1, int toolListID1)
        {
            ToolList = toolList1;
            CurrentToolCategory = currentToolCategory1;
            CategoryId = categoryId1;
            CurrentCategory = currentCategory1;
            CategoryColor = categoryColor1;
            CategoryColorBg = categoryColorBg1;
            ToolDescription = toolDescription1;
            DdlOrderByPrice = new List<SelectListItem>();
            DdlOrderByPrice.Add(new SelectListItem("High to Low", "HtoL"));
            DdlOrderByPrice.Add(new SelectListItem("Low to High", "LtoH"));
            ToolListID = toolListID1;
        }

    }

}




