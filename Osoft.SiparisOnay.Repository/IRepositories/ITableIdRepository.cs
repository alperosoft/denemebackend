using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.Erp.Core.IRepositories
{
    public interface ITableIdRepository : IGenericRepository<TableId>
    {
        Task<IEnumerable<TableId>> GetTableId(int srk_no, int bcmno, int yil, string table_name, string? kategori, string? f_set);
        Task<IEnumerable<TableId>> GetTlmtPrimno();

        Task<IEnumerable<TableId>> GetSpdNo2(int spd_no1);
    }
}