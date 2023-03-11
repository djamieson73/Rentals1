using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Text;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace WebApplication9.Controllers
{
	public class ListingAPIController : Controller
	{

		HttpClientHandler _clientHandler = new HttpClientHandler();

		ToolList _oListing = new ToolList();
		List<ToolList> _oListings = new List<ToolList>(); 

		public ListingAPIController()
		{
			_clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
		}

		public IActionResult Index()
		{

			return View();
		}



        //private ToolList? DeserializeUsingGenericSystemTextJson(string json)
        //{
        //    var toollist = System.Text.Json.JsonSerializer.Deserialize<ToolList>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //    return toollist;
        //}

        //private ToolList? DeserializeUsingNewtonSoftJson(string json)
        //{
        //    var toollist = JsonConvert.DeserializeObject<ToolList>(json);
        //    return toollist;
        //}







        [HttpGet]
		public async Task<List<ToolList>> GetAllListings()
		{
			_oListings = new List<ToolList>();

			using (var httpClient = new HttpClient())
			{
				using (var response=await httpClient.GetAsync("https://localhost:7163/ListingAPI"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					_oListings = JsonConvert.DeserializeObject<List<ToolList>>(apiResponse);
                }
			}
			return _oListings;

		}

		[HttpGet]
		public async Task<ToolList> GetById(int Id)
		{
			_oListing = new ToolList();

			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync("https://localhost:7163/ListingAPI" + Id))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					_oListing = JsonConvert.DeserializeObject<ToolList>(apiResponse);
				}
			}
			return _oListing;

		}


		[HttpPost]
		public async Task<ToolList> AddUpdateListing(ToolList toollist)
		{
			_oListing = new ToolList();

			using (var httpClient = new HttpClient())
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(toollist), Encoding.UTF8, "application/json");
				using (var response = await httpClient.PostAsync("https://localhost:7163/ListingAPI", content))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					_oListing = JsonConvert.DeserializeObject<ToolList>(apiResponse);
				}
			}
			return _oListing;

		}



		[HttpGet]
		public async Task<string> Delete(int Id)
		{
			string message = "";

			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.DeleteAsync("https://localhost:7163/ListingAPI" + Id))
				{
					message = await response.Content.ReadAsStringAsync();
				}
			}
			return message;

		}





	}
}
