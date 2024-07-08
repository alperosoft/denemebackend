using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IDinamikRaporRepository : IGenericRepository<RaporDizayn>
    {
        Task<DinamikRaporColumns?> QueryGetData(string whereValues, int raporId);
    }
}
