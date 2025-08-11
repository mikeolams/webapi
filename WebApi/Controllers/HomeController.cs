using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApi.ViewsModel;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        //private readonly MyDbContext _dbContext;
        //private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        //private IHttpClientFactory httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //var response = await _httpClient.GetAsync("https://localhost:7003/api/RegistrationForm");
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7003/api/RegistrationForm");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var myData = JsonSerializer.Deserialize<List<Registration>>(responseBody);
            // Process the response body
            return View(myData);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
