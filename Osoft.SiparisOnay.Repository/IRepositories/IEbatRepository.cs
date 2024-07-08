using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IEbatRepository : IGenericRepository<Ebat>
    {
        Task<IEnumerable<Ebat>> GetEbatAll(int srk_no);
    }
}
