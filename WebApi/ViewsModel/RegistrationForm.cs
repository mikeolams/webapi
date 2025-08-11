namespace WebApi.ViewsModel
{
    public class RegistrationForm
    {
            public int userId { get; set; }

            public string? fullName { get; set; }
            public string? email { get; set; }
            public string? password { get; set; }
            //public string? password { get; set; }
            public string? ConfirmPassword { get; set; }
            public byte[]? PassportPhotograph { get; set; }
            //public string? passportPhotograph { get; set; }
    }
}
