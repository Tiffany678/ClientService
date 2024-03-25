using ClientManagement.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.API.Models.DTO
{
    public class AddClientRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "First Name has to be a minimum of 1 character")]
        [MaxLength(50, ErrorMessage = "First Name has to be a maxmum of 50 characters")]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(1, ErrorMessage = "Last Name has to be a minimum of 1 character")]
        [MaxLength(50, ErrorMessage = "Last Name has to be a maxmum of 50 characters")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string? ProfileImageUrl { get; set; }
        public Guid HelpServiceId { get; set; }
        public HelpService HelpService { get; set; }
    }
}
