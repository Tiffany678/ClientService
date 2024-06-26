﻿using System.Net;
using System.Reflection;

namespace ClientManagement.API.Models.Domain
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string? ProfileImageUrl { get; set; }
        public Guid HelpServiceId { get; set; }

        // Navigation to HelpService
        public HelpService HelpService { get; set; }

    }
}
