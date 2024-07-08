using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IBankaRepository : IGenericRepository<Banka>
    {
        Task<IEnumerable<Banka>> BankaAll(int srk_no);
    }
}
