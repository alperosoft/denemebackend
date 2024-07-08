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
    public class SpurtRepository : GenericRepository<Spurt>, ISpurtRepository
    {
        private readonly IDbConnection _connection;

        public SpurtRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Spurt>> GetOrguUretim(Filter? filter)
        {
            string sql = $@"SELECT spurt.spu_mak_kod,   
         grup.grp_ad,   
         grup.grp_kod,   
         cmpt_umkt_kg = sum(spu_umkt_kg),   
         cmpt_ubmkt_kg = sum(spu_ubmkt_kg),   
         cmpt_umkt_top = sum(spu_umkt_top)  
    FROM spurt,   
         spd,   
         mamlz,   
         grup  
   WHERE ( spd.spd_primno = spurt.spu_spd_primno ) and  
         ( mamlz.mm_primno = spd.spd_mm_primno ) and  
         ( grup.grp_primno = mamlz.mm_grp_primno ) and  
         ( ( spurt.spu_srk_no = {filter.filterValue1} ) AND  
         ( spurt.spu_bcmno = 115 ) AND  
         ( spurt.spu_spuf_no1 = {filter.filterValue2} ) AND  
         ( spurt.spu_utrh between  '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' and  '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}' ) )   
GROUP BY spurt.spu_umkt_kg,   
         spurt.spu_ubmkt_kg,   
         spurt.spu_mak_kod,   
         grup.grp_kod,   
         grup.grp_ad  
";

            return await _connection.QueryAsync<Spurt, Grup, SpurtCmpt, Spurt>(sql, (spurt, grup, spurtCmpt) =>
            {
                spurt.grup = grup;
                spurt.spurtCmpt = spurtCmpt;
                return spurt;
            },splitOn: "spu_mak_kod,grp_ad,cmpt_umkt_kg");
        }

    }
}
