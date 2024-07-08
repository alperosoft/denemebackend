using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class DinamikRaporFilterRepository : GenericRepository<RaporDizayn_Det>, IDinamikRaporFilterRepository
    {
        private readonly IDbConnection _conn;
        public DinamikRaporFilterRepository(IDbConnection conn) : base(conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<RaporDizayn_Det?>> QueryGetFilter(int raporId)
        {

            string raporDizaynDetSql = $@"SELECT  id,rapor_dizayn_id,colum,operator as 'Operator',deger,tip,tip2,logical,bcmno,caption
                                          FROM dba.rapor_dizayn_det 
                                          WHERE  rapor_dizayn_ID='{raporId}' 
                                          ORDER BY ID DESC";

            var raporDizaynDetValues = await _conn.QueryAsync<RaporDizayn_Det>(raporDizaynDetSql);
            //string raporDizaynSql = $@"SELECT raporid,sorgu FROM dba.rapor_dizayn WHERE  raporid='240'";
            //RaporDizayn raporDizaynValues = await _conn.QueryFirstOrDefaultAsync<RaporDizayn>(raporDizaynSql);

            var raporDizaynDet = new List<RaporDizayn_Det>();

            foreach (var items in raporDizaynDetValues)
            {
                RaporDizayn_Det raporDetModel = new();
                raporDetModel.id = items.id;
                raporDetModel.rapor_dizayn_id = items.rapor_dizayn_id;
                raporDetModel.colum = items.colum;
                raporDetModel.Operator = items.Operator;
                raporDetModel.tip2 = items.tip2;
                raporDetModel.tip = items.tip;
                raporDetModel.deger = items.deger;
                raporDetModel.logical = items.logical;
                raporDetModel.bcmno = items.bcmno;
                raporDetModel.caption = items.caption;

                if (items.tip == "combo")
                {
                    if (!string.IsNullOrEmpty(items.deger))
                    {
                        string raporDizaynDetDegerSql = $@"{items.deger}";

                        var raporDizaynDetDizaynDetDegersValues = await _conn.QueryAsync<RaporDizayn_Det_Deger>(raporDizaynDetDegerSql);

                        foreach (var raporDizaynDetDeger in raporDizaynDetDizaynDetDegersValues.ToArray())
                            raporDetModel.RaporDizayn_Det_Deger.Add(raporDizaynDetDeger);
                    }
                }

                raporDizaynDet.Add(raporDetModel);
            }


            return raporDizaynDet;
        }

    }
}
