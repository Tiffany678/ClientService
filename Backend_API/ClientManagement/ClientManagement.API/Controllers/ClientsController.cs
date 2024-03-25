using AutoMapper;
using ClientManagement.API.Models.Domain;
using ClientManagement.API.Models.DTO;
using ClientManagement.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace ClientManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClientsController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IClientRepository clientRepository;

        public ClientsController(IMapper mapper, IClientRepository clientRepository)
        {
            this.mapper = mapper;
            this.clientRepository = clientRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            var clientsDomainModel = await clientRepository.GetAllAsync(filterOn, filterQuery, sortBy,
                    isAscending ?? true, pageNumber, pageSize);

            return Ok(mapper.Map<List<ClientDto>>(clientsDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var clientsDomainModel = await clientRepository.GetByIdAsync(id);

            if (clientsDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<ClientDto>(clientsDomainModel));
        }


        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddClientRequestDto addClientRequestDto)
        {
            // Map DTO to Domain Model
            var clientDomainModel = mapper.Map<Client>(addClientRequestDto);

            await clientRepository.CreateAsync(clientDomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<ClientDto>(clientDomainModel));
        }


        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateClientRequestDto updateClientRequestDto)
        {

            // Map DTO to Domain Model
            var clientDomainModel = mapper.Map<Client>(updateClientRequestDto);

            clientDomainModel = await clientRepository.UpdateAsync(id, clientDomainModel);

            if (clientDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<ClientDto>(clientDomainModel));
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedClientDomainModel = await clientRepository.DeleteAsync(id);

            if (deletedClientDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<ClientDto>(deletedClientDomainModel));
        }
    }
}
