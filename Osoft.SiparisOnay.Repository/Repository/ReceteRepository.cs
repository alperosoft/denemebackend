using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class ReceteRepository : GenericRepository<Recete>, IReceteRepository
    {
        private readonly IDbConnection _connection;

        public ReceteRepository(IDbConnection connection) : base(connection) 
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Recete>> GetRecete(Filter? filter)
        
        {
            string sql = $@"SELECT 
                                 recete.rt_turu,   
                                 recetegrp.rtgr_kod,   
                                 recetegrp.rtgr_ad,   
                                 cmpt_bakiye_kg = sum(rt_mkt_kg),   
                                 cmpt_bakiye_mt = sum(rt_mkt_mt)  
                            FROM recete,   
                                 recetegrp  
                           WHERE ( recetegrp.rtgr_primno = recete.rt_rtgr_primno ) and  
                                 ( ( recete.rt_srk_no = {filter.filterValue1} ) AND  
                                 ( recete.rt_bcmno = 500 ) AND  
                                 ( recete.rt_sf_trh between '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' and '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}' ) )   
                        GROUP BY recete.rt_turu,   
                                 recetegrp.rtgr_kod,   
                                 recetegrp.rtgr_ad ";

            return await _connection.QueryAsync<Recete, ReceteGrp, ReceteCmpt, Recete>(sql, (recete, receteGrp, receteCmpt) =>
            {
                recete.receteGrp = receteGrp;
                recete.receteCmpt = receteCmpt;
                return recete;
            },splitOn: "rt_turu,rtgr_kod,cmpt_bakiye_kg");
        }
    }
}
