using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModels
{
    public class ToolViewModel
    {

        public IEnumerable<Tool> Tools { get; }

        public string? CatName { get; }

        
        public ToolViewModel(IEnumerable<Tool> tools1, string? catName1)
        {
            Tools = tools1;
            CatName = catName1;
        }


    }
}
