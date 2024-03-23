using ClientManagement.API.Models.Domain;
using System.Runtime.InteropServices;

namespace ClientManagement.API.Repositories
{
    public interface IHelpServiceRepository
    {
        Task<List<HelpService>> GetAllAsync();

       Task<HelpService?> GetByIdAsync(Guid id);
   
       Task<HelpService> CreateAsync(HelpService helpService);
   
       Task<HelpService?> UpdateAsync(Guid id, HelpService helpService);
   
       Task<HelpService?> DeleteAsync(Guid id);
    }
}
