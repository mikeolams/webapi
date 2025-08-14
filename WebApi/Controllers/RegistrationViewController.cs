using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Principal;
using WebApi.ViewsModel;

namespace WebApi.Controllers
{
    public class RegistrationViewController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public RegistrationForm registrationForm { get; set; }

        public void OnGet()
        {
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegistrationForm registrationForm)
        {
            if (!ModelState.IsValid)
            {
                System.Console.WriteLine(100);
                return View(registrationForm);
            }

            try
            {
                var httpClient = new HttpClient();
                
                if (!ModelState.IsValid)
                {
                    foreach (var modelStateKey in ModelState.Keys)
                    {
                        var modelStateVal = ModelState[modelStateKey];
                        foreach (var error in modelStateVal.Errors)
                        {
                            Console.WriteLine(error);
                            Console.WriteLine($"Error: {error.ErrorMessage}");
                        }
                    }
                }
                Console.WriteLine(JsonConvert.SerializeObject(registrationForm));
                
                //var response = await httpClient.PostAsJsonAsync("https://localhost:7003/api/RegistrationForm", registrationForm);
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(registrationForm.FullName), "FullName");
                content.Add(new StringContent(registrationForm.Email), "Email");
                content.Add(new StringContent(registrationForm.Password), "Password");
                content.Add(new StringContent(registrationForm.ConfirmPassword), "ConfirmPassword");
                //content.Add(new StreamContent(File.OpenRead("path/to/file")), "PassportPhotograph", "file.name");

                var response = await httpClient.PostAsync("https://localhost:7003/api/RegistrationForm", content);

                if (response.IsSuccessStatusCode)
                {
                    //System.Console.WriteLine(registrationForm);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error occurred while processing your request.");
                    var errorContent = await response.Content.ReadAsStringAsync();
                    // Log or display the error content
                    return View(registrationForm);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
                return View(registrationForm);
            }
        }
    }
}

