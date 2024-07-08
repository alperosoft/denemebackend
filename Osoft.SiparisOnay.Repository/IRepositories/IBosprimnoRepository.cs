using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IBosprimnoRepository : IGenericRepository<bosprimno>
    {
        Task<bosprimno?> GetPrimNo(string bos_tablo,int bos_srk_no,int bos_bcmno);
    }
}
