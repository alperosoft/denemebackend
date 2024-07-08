using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Osoft.SiparisOnay.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        private readonly IDbConnection _conn;
        public UserRepository(IDbConnection conn) : base(conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<User>> UserAll(int srk_no)
        {

            string sql = @$"SELECT  * from users where srk_no={srk_no}";
            return await _conn.QueryAsync<User>(sql);

        }

        public async Task<IEnumerable<User>> UserLogin(Filter filter)
        {
            string sql = "SELECT TOP 1 * FROM users JOIN sirket ON users.srk_no = sirket.srk_no " +
                         "WHERE sirket.srk_srk_no = ? " +
                         "AND users.srk_no = ? " +
                         "AND users.us_kod = ? " +
                         "AND users.us_pasifre = ?";

            var parameters = new
            {
                filter.filterValue1,
                filter.filterValue2,
                filter.filterValue20,
                filter.filterValue21
            };

            return await _conn.QueryAsync<User>(sql, parameters);

            /*
  filterValue1 -> srk_srk_no
  filterValue2 -> srk_no
  filterValue20 -> us_kod
  filterValue21 -> us_pasifre
  */
        }

    }
}