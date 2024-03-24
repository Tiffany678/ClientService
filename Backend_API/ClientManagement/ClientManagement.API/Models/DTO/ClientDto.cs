using ClientManagement.API.Models.Domain;

namespace ClientManagement.API.Models.DTO
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string? ProfileImageUrl { get; set; }
        public Guid HelpServiceId { get; set; }
        public HelpService HelpService { get; set; }

    }
}
