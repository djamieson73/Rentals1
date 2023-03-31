using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Entities.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApplication9.Controllers
{
    public class CityController : Controller
    {

        HttpClientHandler _clientHandler = new HttpClientHandler();
        List<City> _oCity = new List<City>();

        public CityController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        }


      //  [HttpPost]
        public async Task<IActionResult> Index(string? name, string? searchQuery, int pageNumber = 1, int pageSixe = 10)
        {


            //using (var httpClient = new HttpClient(_clientHandler))
            using (var httpClient = new HttpClient())
            {
                // using (var response = await httpClient.GetAsync("https://localhost:7047/api/Cities/"))  
                   using (var response = await httpClient.GetAsync("http://54.236.42.250:8081/api/Cities/"))  
               // using (var response = await httpClient.GetAsync("http://localhost:8081/api/Cities/"))

                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oCity = JsonConvert.DeserializeObject<List<City>>(apiResponse);
                    return View(_oCity);
                }
            }

        }

    }
}
