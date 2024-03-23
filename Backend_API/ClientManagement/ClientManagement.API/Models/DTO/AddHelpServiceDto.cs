using System.ComponentModel.DataAnnotations;

namespace ClientManagement.API.Models.DTO
{
    public class AddHelpServiceDto
    {
     //   [Required]
     //   [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string ServiceName { get; set; }

        public string Description { get; set; }
    }
}
