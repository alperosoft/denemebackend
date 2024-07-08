using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IFirmaRepository : IGenericRepository<Firma>
    {
        Task<IEnumerable<Firma>> GetFirmaAll(int srk_no, string? ktgr_kod, int frm_tur);
        Task<IEnumerable<Firma>> GetFirma(int srk_no, string frm_kod);
        Task<IEnumerable<FirmaDist>> GetFirmaDistAll(int srk_no);
        Task<IEnumerable<FirmaDist>> GetFirmaDist(int srk_no, string? frmd_kod);
        Task<IEnumerable<Firmadr>> GetFirmadrAll(int srk_no, string frm_kod);
        Task<Firma> Next(int srk_no, string frm_kod);
        Task<Firma> Previous(int srk_no, string frm_kod);
        Task<IEnumerable<Firma>> GetList(Firma firma);
        Task<int> FirmaDelete(int srk_no, string frm_kod);
    }
}
