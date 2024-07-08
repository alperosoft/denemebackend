using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IVardiyaRepository : IGenericRepository<Vardiya>
    {
        Task<IEnumerable<Vardiya>> GetVardiya(int srk_no);
    }
}
