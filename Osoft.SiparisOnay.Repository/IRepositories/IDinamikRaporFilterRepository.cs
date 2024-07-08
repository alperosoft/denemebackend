using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IDinamikRaporFilterRepository : IGenericRepository<RaporDizayn_Det>
    {
        Task<IEnumerable<RaporDizayn_Det?>> QueryGetFilter(int raporId);
    }
}
