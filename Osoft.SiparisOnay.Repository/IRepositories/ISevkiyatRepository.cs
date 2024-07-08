using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface ISevkiyatRepository : IGenericRepository<Svkfatd>
    {
        Task<IEnumerable<Spkateg>> GetSevkiyat(Filter? filter);
    }
}
