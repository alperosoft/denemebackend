using Dapper;
using Microsoft.IdentityModel.Tokens;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;
using System.Runtime.InteropServices.Marshalling;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class FirmagrpRepository : GenericRepository<Firmagrp>, IFirmagrpRepository
    {
        private readonly IDbConnection _connection;

        public FirmagrpRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Firmagrp>> FirmagrpAll(int srk_no)
        {
            string sql = @$"SELECT * from firmagrp where srk_no={srk_no} ";
            return await _connection.QueryAsync<Firmagrp>(sql);
        }
    }
}
