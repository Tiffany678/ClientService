using AutoMapper;
using ClientManagement.API.Models.Domain;
using ClientManagement.API.Models.DTO;
using ClientManagement.API.Repositories;
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




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddClientRequestDto addClientRequestDto)
        {
            // Map DTO to Domain Model
            var clientDomainModel = mapper.Map<Client>(addClientRequestDto);

            await clientRepository.CreateAsync(clientDomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<ClientDto>(clientDomainModel));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientsDomainModel = await clientRepository.GetAllAsync();
            return Ok(mapper.Map<List<ClientDto>>(clientsDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
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

        [HttpPut]
        [Route("{id:Guid}")]
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
