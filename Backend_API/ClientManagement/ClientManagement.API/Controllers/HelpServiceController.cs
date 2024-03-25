using ClientManagement.API.Data;
using ClientManagement.API.Models.DTO;
using ClientManagement.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ClientManagement.API.Models.Domain;
namespace ClientManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpServiceController : ControllerBase
    {
        private readonly ClientsDbContext dbContext;
        private readonly IHelpServiceRepository helpServiceRepository;
        private readonly IMapper mapper;


        public HelpServiceController(ClientsDbContext dbContext,
            IHelpServiceRepository helpServiceRepository,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.helpServiceRepository = helpServiceRepository;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var helpServiceDomain = await helpServiceRepository.GetAllAsync();

            return Ok(mapper.Map<List<HelpServiceDto>>(helpServiceDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            // Get Region Domain Model From Database
            var helpServiceDomain = await helpServiceRepository.GetByIdAsync(id);

            if (helpServiceDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<HelpServiceDto>(helpServiceDomain));
        }

//       [HttpPost]
//
//       public async Task<IActionResult> Create([FromBody] AddHelpServiceDto addHelpServiceDto)
//       {
//           // Map or Convert DTO to Domain Model
//           var helpServiceDomainModel = mapper.Map<HelpService>(addHelpServiceDto);
//
//           // Use Domain Model to create Region
//           helpServiceDomainModel = await helpServiceRepository.CreateAsync(helpServiceDomainModel);
//
//           // Map Domain model back to DTO
//           var helpServiceDto = mapper.Map<HelpServiceDto>(helpServiceDomainModel);
//
//           return CreatedAtAction(nameof(GetById), new { id = helpServiceDto.Id }, helpServiceDto);
//       }
//      
//       [HttpPut]
//       [Route("{id:Guid}")]
//   
//       public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateHelpServiceDto updateHelpServiceDto)
//       {
//
//           // Map DTO to Domain Model
//           var helpServiceDomainModel = mapper.Map<HelpService>(updateHelpServiceDto);
//
//           // Check if region exists
//           helpServiceDomainModel = await helpServiceRepository.UpdateAsync(id, helpServiceDomainModel);
//
//           if (helpServiceDomainModel == null)
//           {
//               return NotFound();
//           }
//
//           return Ok(mapper.Map<HelpServiceDto>(helpServiceDomainModel));
//       }
//
//
//
//       [HttpDelete]
//       [Route("{id:Guid}")]
// 
//       public async Task<IActionResult> Delete([FromRoute] Guid id)
//       {
//           var helpServiceDomainModel = await helpServiceRepository.DeleteAsync(id);
//
//           if (helpServiceDomainModel == null)
//           {
//               return NotFound();
//           }
//
//           return Ok(mapper.Map<HelpServiceDto>(helpServiceDomainModel));
//       }
//
//
      

    }
}
