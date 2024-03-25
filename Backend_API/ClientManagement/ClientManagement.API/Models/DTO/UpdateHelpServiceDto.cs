using System.ComponentModel.DataAnnotations;

namespace ClientManagement.API.Models.DTO
{
    public class UpdateHelpServiceDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string ServiceName { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Name has to be a maximum of 1000 characters")]
        public string Description { get; set; }
    }
}
