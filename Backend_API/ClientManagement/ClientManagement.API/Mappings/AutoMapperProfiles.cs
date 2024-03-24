using AutoMapper;
using ClientManagement.API.Models.Domain;
using ClientManagement.API.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientManagement.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<HelpService, HelpServiceDto>().ReverseMap();
            CreateMap<HelpService, AddHelpServiceDto>().ReverseMap();
            CreateMap<HelpService, UpdateHelpServiceDto>().ReverseMap();

            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, AddClientRequestDto>().ReverseMap();
            CreateMap<Client, UpdateClientRequestDto>().ReverseMap();

        }
    }
}