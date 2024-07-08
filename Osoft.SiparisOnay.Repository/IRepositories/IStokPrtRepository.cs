using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IStokPrtRepository: IGenericRepository<StokPrt>
    {
        Task<IEnumerable<decimal>> GetTotalSum(int srk_no, int bcmno, int yil, int dp_no, int mm_primno, int cl_primno, string birim);

        Task<IEnumerable<StokPrt>> GetMaliyet(int srk_no, int bcmno, int yil, int dp_no);
    }
}
