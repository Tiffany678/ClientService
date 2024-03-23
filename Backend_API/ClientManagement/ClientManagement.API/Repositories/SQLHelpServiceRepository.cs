using ClientManagement.API.Data;
using ClientManagement.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClientManagement.API.Repositories
{
    public class SQLHelpServiceRepository: IHelpServiceRepository
    {
        private readonly ClientsDbContext dbContext;

        public SQLHelpServiceRepository(ClientsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<HelpService>> GetAllAsync()
        {
            return await dbContext.HelpServices.ToListAsync();
        }

       public async Task<HelpService?> GetByIdAsync(Guid id)
       {
           return await dbContext.HelpServices.FirstOrDefaultAsync(x => x.Id == id);
       }
     
       public async Task<HelpService> CreateAsync(HelpService helpService)
       {
            await dbContext.HelpServices.AddAsync(helpService);
            await dbContext.SaveChangesAsync();
            return helpService;
       }
       public async Task<HelpService?> UpdateAsync(Guid id, HelpService helpService)
       {
            var existingHelpService = await dbContext.HelpServices.FirstOrDefaultAsync(x => x.Id == id);

            if (existingHelpService == null)
            {
                return null;
            }


            existingHelpService.ServiceName = helpService.ServiceName;
            existingHelpService.Description = helpService.Description;


            await dbContext.SaveChangesAsync();
            return existingHelpService;
        }
     
       public async Task<HelpService?> DeleteAsync(Guid id)
       {
            var existingHelpService = await dbContext.HelpServices.FirstOrDefaultAsync(x => x.Id == id);

            if (existingHelpService == null)
            {
                return null;
            }

            dbContext.HelpServices.Remove(existingHelpService);
            await dbContext.SaveChangesAsync();
            return existingHelpService;
        }
    }
}
