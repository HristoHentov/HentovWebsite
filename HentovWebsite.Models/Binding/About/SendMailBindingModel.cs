using System.ComponentModel.DataAnnotations;

namespace HentovWebsite.Models.Binding.About
{
    public class SendMailBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
