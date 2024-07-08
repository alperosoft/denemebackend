using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IStkfRepository:IGenericRepository<Stkf>
    {
        Task<IEnumerable<Stkf>> GetTahsilat(Stkf stkf);
        Task<IEnumerable<Stkf>> GetList(Stkf stkf);
        Task<Stkf?> Find(int sf_srk_no, int sf_bcmno, int sf_no2, int sf_fist_no);
        Task<Stkf> Next(int sf_srk_no, int sf_bcmno, int sf_no2,int sf_fist_no);
        Task<Stkf> Previous(int sf_srk_no, int sf_bcmno, int sf_no2, int sf_fist_no);
    }
}
