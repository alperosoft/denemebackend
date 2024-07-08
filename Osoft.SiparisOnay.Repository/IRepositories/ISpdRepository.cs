using Newtonsoft.Json.Linq;
using Osoft.SiparisOnay.Core.Models;
using System.Text.Json;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface ISpdRepository : IGenericRepository<Spd>
    {
        Task<IEnumerable<decimal>> GetSpdTotalSum(int srk_no, int mm_primno, int cl_primno);
        Task<IEnumerable<Spd>> GetSpd(Filter? filter);
        Task<IEnumerable<Spd>> GetSpdFiltre(Filter? filter);
        Task<int> InsertSpd(JsonElement data);
        Task<int> UpdateSpd(string sp_primno, string spNo2Value, JsonElement data);
        Task<IEnumerable<int>> GetSpdPrimno(int spd_no1);

    }
}