using ClientManagement.API.Models.Domain;

namespace ClientManagement.API.Repositories
{
    public interface IClientRepository
    {

        Task<List<Client>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100);

        Task<Client?> GetByIdAsync(Guid id);

        Task<Client> CreateAsync(Client client);

        Task<Client?> UpdateAsync(Guid id, Client client);

        Task<Client?> DeleteAsync(Guid id);
    }
}
