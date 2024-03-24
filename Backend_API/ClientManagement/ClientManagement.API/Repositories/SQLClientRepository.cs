using ClientManagement.API.Data;
using ClientManagement.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClientManagement.API.Repositories
{
    public class SQLClientRepository : IClientRepository
    {
        private readonly ClientsDbContext dbContext;

        public SQLClientRepository(ClientsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Client> CreateAsync(Client client)
        {
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> DeleteAsync(Guid id)
        {
            var existingClient = await dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (existingClient == null)
            {
                return null;
            }

            dbContext.Clients.Remove(existingClient);
            await dbContext.SaveChangesAsync();
            return existingClient;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await dbContext.Clients.Include("HelpService").ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(Guid id)
        {
            return await dbContext.Clients
                .Include("HelpService")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client?> UpdateAsync(Guid id, Client client)
        {
            var existingClient = await dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (existingClient == null)
            {
                return null;
            }


            existingClient.FirstName = client.FirstName;
            existingClient.LastName = client.LastName;
            existingClient.DateOfBirth = client.DateOfBirth;
            existingClient.Email = client.Email;
            existingClient.Mobile = client.Mobile;
            existingClient.ProfileImageUrl = client.ProfileImageUrl;
            existingClient.HelpServiceId = client.HelpServiceId;

            await dbContext.SaveChangesAsync();

            return existingClient;
        }
    }
}
