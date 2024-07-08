using Dapper;
using Osoft.Erp.Core.IRepositories;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repositories
{
    public class TableIdRepository : GenericRepository<TableId>, ITableIdRepository
    {
        private readonly IDbConnection _connection;

        public TableIdRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<TableId>> GetTableId(int srk_no, int bcmno, int yil, string table_name, string? kategori, string? f_set)
        {
            string sql = $@"SELECT f_id FROM table_id WHERE srk_no={srk_no} AND bcmno= {bcmno} AND yil={yil} AND table_name= '{table_name}' AND kategori='{kategori}' AND f_set= '{f_set}'";
            return await _connection.QueryAsync<TableId>(sql);
        }

        public async Task<IEnumerable<TableId>> GetTlmtPrimno()
        {
            string sql = $@"SELECT MAX(spd_tlmt_primno) AS f_id FROM spd;";
            return await _connection.QueryAsync<TableId>(sql);
        }

        public async Task<IEnumerable<TableId>> GetSpdNo2(int spd_no1)
        {
            string sql = $@"SELECT MAX(spd_no2) AS f_id FROM spd WHERE spd_no1 = {spd_no1}";
            return await _connection.QueryAsync<TableId>(sql);
        }
    }
}
