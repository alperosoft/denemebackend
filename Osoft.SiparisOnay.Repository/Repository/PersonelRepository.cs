using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class PersonelRepository : GenericRepository<Personel>, IPersonelRepository
    {
        private readonly IDbConnection _connection;

        public PersonelRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Personel>> GetPersonelAll()
        {
        string sql = @$"SELECT per_no,per_ad,per_soyad FROM personel";

        return await _connection.QueryAsync<Personel>(sql);
        }


    }
}
