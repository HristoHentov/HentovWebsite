using System.ComponentModel.DataAnnotations;

namespace HentovWebsite.Models.View.ManageAccount
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}