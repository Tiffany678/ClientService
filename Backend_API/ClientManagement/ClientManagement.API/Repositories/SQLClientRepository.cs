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

        public async Task<List<Client>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100)
        {
           var clients = dbContext.Clients.Include("HelpService").AsQueryable();

            // Filtering
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
            
                if (filterOn.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    clients = clients.Where(x => x.FirstName.Contains(filterQuery));
                }
                else if (filterOn.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                {
                    clients = clients.Where(x => x.LastName.Contains(filterQuery));
                }

            }
            // Sorting 
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    clients = isAscending ? clients.OrderBy(x => x.FirstName) : clients.OrderByDescending(x => x.FirstName);
                }
                else if (sortBy.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                {
                    clients = isAscending ? clients.OrderBy(x => x.LastName) : clients.OrderByDescending(x => x.LastName);
                }
            }

            // Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await clients.Skip(skipResults).Take(pageSize).ToListAsync();
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
