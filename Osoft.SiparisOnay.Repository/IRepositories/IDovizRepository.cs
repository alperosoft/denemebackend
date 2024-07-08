using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IDovizRepository : IGenericRepository<Doviz>
    {
        Task<IEnumerable<Doviz>> GetDovizAll();
    }
}
