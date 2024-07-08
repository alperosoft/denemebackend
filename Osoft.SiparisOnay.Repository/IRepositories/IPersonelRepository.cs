using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IPersonelRepository : IGenericRepository<Personel>
    {
        Task<IEnumerable<Personel>> GetPersonelAll();
    }
}