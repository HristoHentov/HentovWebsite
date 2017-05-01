using System.ComponentModel.DataAnnotations;

namespace HentovWebsite.Models.View.ManageLogin
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
