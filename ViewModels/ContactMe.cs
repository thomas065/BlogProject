using System.ComponentModel.DataAnnotations;

namespace BlogProject.ViewModels
{
    public class ContactMe
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long. ", MinimumLength = 2)]
        public string Subject { get; set; }

        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long. ", MinimumLength = 2)]
        public string Message { get; set; }
    }
}
