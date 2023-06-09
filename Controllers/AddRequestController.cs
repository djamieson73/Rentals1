﻿using Entities;
using Entities.Models;
using Entities.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO.Pipelines;

namespace WebApplication9.Controllers
{

    //This controller sends an email to the tool renter alerting them that someone is interested in renting their tool
    //This controller adds a request to the Requests table
    public class AddRequestController : Controller
    {
        private readonly IToolListRepository _toolListRepository;
        private readonly IToolRepository _toolRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRequestsRepository _requestsRepository;
        public AddRequestController(IToolListRepository toollistRepository, IToolRepository toolRepository, ICategoryRepository categoryRepository, IRequestsRepository requestsRepository)
        {
            _toolListRepository = toollistRepository;
            _toolRepository = toolRepository;
            _categoryRepository = categoryRepository;
            _requestsRepository = requestsRepository;
        }


        public IActionResult Index(string Id)
        {

            int? ToolID;
            ToolID = _toolListRepository.ToolList.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.ToolId;

            string? CurrentToolCategory;
            CurrentToolCategory = _toolRepository.AllTools.FirstOrDefault(c => c.Id == Convert.ToInt32(ToolID))?.ToolName;

            string? ToolDescription;
            ToolDescription = _toolListRepository.ToolList.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.Description;

            int? iPrice;
            iPrice = _toolListRepository.ToolList.FirstOrDefault(c => c.Id == Convert.ToInt32(Id))?.Price;
            string Price = String.Format("{0:C}", iPrice);

            DateTime DateIn = DateTime.Today;

            string Message = "";

            DateTime RequestDate = DateTime.Today;

            int ListId = Convert.ToInt32(Id);

            string RenterId = "";
            RenterId = "user999";

            return View(new AddRequestViewModel(CurrentToolCategory, ToolDescription, Price, ToolID, DateIn, RequestDate, Message, RenterId, ListId));

        }


        [HttpPost]
        public IActionResult FormsTestPost([FromForm] AddRequestViewModel model) //FromBody is for APIs
        {
            if (ModelState.IsValid == false)
            {
                return View("~/Views/AddRequest/index.cshtml", model);
            }

            var requests = new Request();
                requests.RenterId = model?.RenterId;
                requests.ListId = Convert.ToInt32(model?.ListId); ///int.tryParse
                requests.Message = model?.Message;
                requests.DateIn = Convert.ToDateTime(model?.DateIn);  // datetime.tryParse

            _requestsRepository.SaveRequest(requests);
            return RedirectToAction("Index", "Category");

        }

    }
}
