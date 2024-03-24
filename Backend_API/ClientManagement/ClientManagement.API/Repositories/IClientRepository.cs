using ClientManagement.API.Models.Domain;

namespace ClientManagement.API.Repositories
{
    public interface IClientRepository
    {

        Task<List<Client>> GetAllAsync();

        Task<Client?> GetByIdAsync(Guid id);

        Task<Client> CreateAsync(Client client);

        Task<Client?> UpdateAsync(Guid id, Client client);

        Task<Client?> DeleteAsync(Guid id);
    }
}
