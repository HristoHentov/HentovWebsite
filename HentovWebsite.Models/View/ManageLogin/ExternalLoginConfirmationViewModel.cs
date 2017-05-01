using System.ComponentModel.DataAnnotations;

namespace HentovWebsite.Models.View.ManageLogin
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}