using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Models.ViewModels
{
    public class AddRequestViewModel
    {
        public string? CurrentToolCategory { get; }
        public string? ToolDescription { get; }
        public string? Price { get; }
        public int? ToolID { get; }

        //*************************************************************

        [Required(ErrorMessage = "Please select a date")]
        [Display(Name = "Request Date")]
       // [StringLength(10)]
        [RegularExpression(@"^((19|20)\\d\\d)-(0?[1-9]|1[012])-(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The date is not in the correct format.")]

        public DateTime? DateIn { get; set; }
        public DateTime? RequestDate { get; set; }

        [Required(ErrorMessage = "Please include a message")]
        [Display(Name = "Message")]
        [StringLength(250)]
        public string? Message { get; set; }
        public string? RenterId { get; set; }
        public int? ListId { get; set; }


        public AddRequestViewModel()
        { }


        public AddRequestViewModel(string? currentToolCategory1, string? toolDescription1, string? Price1, int? toolID1, DateTime? dateIn1, DateTime? requestDate1, string? message1, string? renterId1, int? listId1)
        { 
            CurrentToolCategory = currentToolCategory1;
            ToolDescription = toolDescription1;
            Price = Price1;
            ToolID = toolID1;
            DateIn = dateIn1;
            RequestDate = requestDate1;
            Message = message1;
            RenterId = renterId1;
            ListId = listId1;

        }
    }
}
