using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IBirimRepository : IGenericRepository<Birim>
    {
        Task<IEnumerable<Birim>> GetBirimAll();
    }
}
