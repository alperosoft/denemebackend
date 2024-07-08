using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface ILbRepository : IGenericRepository<Spkateg>
    {
        Task<IEnumerable<Lb>> GetLbAll(int srk_no);
    }
}