using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IMamlzRepository : IGenericRepository<Mamlz>
    {
        Task<IEnumerable<Mamlz>> GetRofMamlz(string param, int mm_primno);
        Task<IEnumerable<Mamlz>> GetMamlzYardim(Filter? filter);
        Task<IEnumerable<Mamlz>> GetMamlz(int an_srk_no, int an_tur, int an_mlz_tur, int an_left, string as_left_kod, string as_kod_i, string as_kod_s, int an_yok);
        Task<IEnumerable<Mamlz>> GetAll(int srk_no);
    }
}
