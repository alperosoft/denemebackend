using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IDepoRepository : IGenericRepository<Depo>
    {
        Task<IEnumerable<Depo>> GetDepo(int srk_no);
    }
}
