using System.ComponentModel.DataAnnotations;

namespace HentovWebsite.Models.View.ManageLogin
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}