using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewsModel
{


    public class RegistrationForm
    {
        //public int userId { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
            public string? Password { get; set; }
        //public string? password { get; set; }
        [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        //public byte[]? PassportPhotograph { get; set; }
        [Required]
        [Controllers.RegistrationViewController.AllowedFileExtensions(new[] { ".jpg", ".png" })]
        public IFormFile? PassportPhotograph { get; set; }
            //public IFormFile? PassportPhotograph { get; set; }
        //{"FullName":null,"Email":null,"Password":null,"ConfirmPassword":null}
        //}

    }

    

}





/// api / RegistrationForm

//public class RegistrationModel : PageModel
//{
//    [BindProperty]
//    public Registration registration { get; set; }

//    public void OnGet()
//    {
//    }

//    public IActionResult OnPost()
//    {
//        if (!ModelState.IsValid)
//        {
//            return Page();
//        }

//        // Call your API endpoint or process the registration data
//        // You can use HttpClient to call your API endpoint
//        var httpClient = new HttpClient();
//        var response = await httpClient.PostAsJsonAsync("/api/registrationform", registration);

//        return RedirectToPage("/Home");
//    } 