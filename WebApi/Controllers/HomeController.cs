using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Web.Helpers;
using WebApi.ViewsModel;
using static System.Reflection.Metadata.BlobBuilder;
using RegistrationForm = WebApi.ViewsModel.RegistrationForm;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        //private readonly MyDbContext _dbContext;
        //private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        //private IHttpClientFactory httpClientFactory;
        //private readonly ImageFileMachine passportPhotograph;
        private readonly IFormFile passportPhotograph;

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

        //public IActionResult Delete(int? userId)
        public async Task<IActionResult> DeleteGet(int? userId)
        {

            if (userId == null)
            {
                //Console.WriteLine(1010);
                return NotFound();
            }
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://localhost:7003/api/RegistrationForm/{userId}");
            //Console.WriteLine(response.StatusCode);
            //Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var registration = await response.Content.ReadFromJsonAsync<Registration>();
                return View("Delete",registration);
            }
            else
            {
                Console.WriteLine(5050);
                return NotFound();
            }
            //return View();
            // retrieve your registration model here
            //var registration = Registration
            //return View("Delete", registration);
            //return View("~/Views/Home/Delete.cshtml");
            //return View("~/Views/Home/Edit.cshtml");
        }


        public async Task <IActionResult> EditGet(int? userId)
        {
            if (userId == null)
            {
                return NotFound();
            }
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://localhost:7003/api/RegistrationForm/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var registration = await response.Content.ReadFromJsonAsync<Registration>();
                return View("Edit", registration);
            }
            else
            {
                return NotFound();
            }
  
            //return View("~/Views/Home/Edit.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? userId, Registration registration)
        {
            if (userId == null)
            {
                return NotFound();
            }
            Console.WriteLine($"checkb4code: " + registration);

            if (ModelState.IsValid)
            {
                // Map Registration object properties to UpdateRegistrationFormDto properties
                //var updateRegistrationFormDto = new UpdateRegistrationFormDto
                //{
                //    UserId = registration.userId,
                //    FullName = registration.fullName,
                //    Email = registration.email,
                //    Password = registration.password,
                //    ConfirmPassword = registration.password,
                //    // ConfirmPassword = registration.confirmPassword, // Uncomment if confirmPassword is available in Registration model
                //    PassportPhotograph = passportPhotograph
                //};

                var httpClient = _httpClientFactory.CreateClient();
                Console.WriteLine($"check " + registration);
                //var json = JsonSerializer.Serialize(updateRegistrationFormDto);
                ////var json = JsonSerializer.Serialize(registration);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync($"https://localhost:7003/api/RegistrationForm?UserId={userId}&FullName={registration.fullName}&Email={registration.email}&Password={registration.password}&ConfirmPassword={registration.password}", null);
                //var response = await httpClient.PutAsync($"https://localhost:7003/api/RegistrationForm?userId={userId}", content);
                //var response = await httpClient.PutAsync($"https://localhost:7003/api/RegistrationForm/{userId}", content);
                //'https://localhost:7003/api/RegistrationForm?UserId=1&FullName=striooppng%201&Email=sjn%40ing.vb&Password=str000ing1&ConfirmPassword=str000ing1'

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to update registration.");
                }
            }

            return View("Edit");
            //return View("Edit", registration);
        }


        public async Task <IActionResult> DetailGet(int? userId)
        {
            if (userId == null)
            {
                return NotFound();
            }
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://localhost:7003/api/RegistrationForm/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var registration = await response.Content.ReadFromJsonAsync<Registration>();
                return View("Detail", registration);
            }
            else
            {
                return NotFound();
            }
            //return View("~/Views/Home/Detail.cshtml");
        }


        [HttpGet]
        public async Task<IActionResult> OnGetAsync(int? userId)
        {
            if (userId == null)
            {
                return RedirectToAction("Index");
                //return RedirectToAction("Index", "Home");
            }
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7003/api/RegistrationForm");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var myData = JsonSerializer.Deserialize<List<Registration>>(responseBody);
            var registrations = myData.FirstOrDefault(e => e.userId == userId);

            if (registrations == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

                // Assuming RegistrationForm or similar
                var viewModel = new RegistrationForm
                {
                    Registration = registrations
                };
                return View(viewModel);
                //Registration = registrations;
                //return View("Index");
            }
        }

        //public async Task<IActionResult> OnPostAsync(int? userId)?
        [HttpPost]
        public async Task<IActionResult> Delete(int? userId)
        {
            if (userId == null)
            {
                return View();
            }

            //var registrationForms = await context.RegistrationForm.FindAsync(id);
            var httpClient = _httpClientFactory.CreateClient();
            //var response = await httpClient.GetAsync("https://localhost:7003/api/RegistrationForm");
            //response.EnsureSuccessStatusCode();
            //var responseBody = await response.Content.ReadAsStringAsync();
            //var myData = JsonSerializer.Deserialize<List<Registration>>(responseBody);
            //var registration = myData.FirstOrDefault(e => e.userId == userId);

            //if (registration == null)
            //{
            //    return View();
            //}
            //else
            //{
                try
                {
                var deleteResponse = await httpClient.DeleteAsync($"https://localhost:7003/api/RegistrationForm?id={userId}");
                deleteResponse.EnsureSuccessStatusCode();

                    return RedirectToAction("Index");
                }

                catch (HttpRequestException ex)
                    {
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                            return StatusCode((int)HttpStatusCode.InternalServerError);
                        }
                        else
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            return StatusCode((int)HttpStatusCode.InternalServerError);
                        }
                    }

            //catch (HttpRequestException ex)
            //    {
            //    var responseContent = await ex.Response.Content.ReadAsStringAsync();
            //    //var responseContent = await ex.
            //    Console.WriteLine(ex);
            //    Console.WriteLine($"Error: {ex.Message}");
            //        //Console.WriteLine($"Response content: {responseContent}");
            //        return StatusCode((int)HttpStatusCode.InternalServerError);
            //}
            // To delete the registration from the API/RegistrationForm?id=40
            // Typically sending a DELETE request to the API
            //var deleteResponse = await httpClient.DeleteAsync($"https://localhost:7003/api/RegistrationForm/{userId}");

            //}
        }

        //[HttpGet]
        //public async Task<IActionResult> Delete(int? userId)
        //{
        //    // code to display the delete view
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteConfirmed(int? userId)
        //{
        //    // code to delete the item
        //}



    }
}
