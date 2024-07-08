using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface ISpkategRepository : IGenericRepository<Spkateg>
    {
        Task<IEnumerable<Spkateg>> GetSpkategAll(int srk_no);
    }
}