using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface ISpwoRepository : IGenericRepository<Spwo>
    {
        Task<IEnumerable<Spwo>> GetUretim(Filter? filter);
    }
}
