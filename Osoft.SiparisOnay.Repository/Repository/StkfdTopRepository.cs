using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;
using Dapper;

namespace Osoft.SiparisOnay.Repository.Repository;

public class StkfdTopRepository : GenericRepository<stkfdtop>, IStkfdTopRepository
{
    private readonly IDbConnection _connection;
    public StkfdTopRepository(IDbConnection connection) : base(connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<stkfdtop>> Find(int sfd_srk_no, int sfd_bcmno, int sfd_sf_primno)
    {
        string sql = @$"SELECT * FROM stkfdtop WHERE  sfd_srk_no='{sfd_srk_no}' AND sfd_bcmno={sfd_bcmno} AND sfd_sf_primno='{sfd_sf_primno}'";
        return await _connection.QueryAsync<stkfdtop>(sql);
    }
}