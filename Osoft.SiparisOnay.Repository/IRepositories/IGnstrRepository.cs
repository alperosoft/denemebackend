using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IGnstrRepository : IGenericRepository<Gnstr>
    {
        Task<IEnumerable<Gnstr>> Gnstr(int srk_no, int gs_bcmno);
        Task<IEnumerable<Gnstr>> GetGnstr(int srk_no, List<string> gs_primno);
    }
}