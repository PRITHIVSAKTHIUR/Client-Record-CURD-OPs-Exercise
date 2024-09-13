//DTO Creating - Clients -- Controllers

using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ClientDto
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required, Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }

        [Required]
        public string Status { get; set; } = ""; //May be [ New, Permenant, Lead, Occasional, Inactive]

    }
}
