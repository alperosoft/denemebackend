using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IReceteRepository : IGenericRepository<Recete>
    {
        Task<IEnumerable<Recete>> GetRecete(Filter? filter);
    }
}
