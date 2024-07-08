using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class KanbanBoardRepository : GenericRepository<kanban_board>, IKanbanBoardRepository
    {
        private readonly IDbConnection _connection;
        public KanbanBoardRepository(IDbConnection conn) : base(conn)
        {
            _connection = conn;
        }

        public async Task<IEnumerable<kanban_board>> Get(string us_kod)
        {
            var param = new { us_kod };
            string sql = $@"SELECT * FROM kanban_board WHERE kullanici_kodu=:us_kod";

            return await _connection.QueryAsync<kanban_board>(sql, param);
        }

        public async Task<int> Delete(string us_kod, string srk_no)
        {
            var param = new { srk_no, us_kod };
            return await _connection.ExecuteAsync(@$"DELETE FROM kanban_board WHERE srk_no=:srk_no AND kullanici_kodu=:us_kod", param);


        }
    }
}
