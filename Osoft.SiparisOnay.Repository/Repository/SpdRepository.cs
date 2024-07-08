using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;
using System.Dynamic;
using System.Text;
using System.Text.Json;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class SpdRepository : GenericRepository<Spd>, ISpdRepository
    {
        private readonly IDbConnection _connection;

        public SpdRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<int>> GetSpdPrimno(int spd_no1)
        {
            string sql = @$"SELECT MAX(spd_sipno) FROM spd WHERE spd_no1 = {spd_no1}";

            return await _connection.QueryAsync<int>(sql, new { spd_no1 });
        }

        public async Task<int> UpdateSpd(string columnName, string columnValue, JsonElement jsonData)
        {
            string updateQuery = await CreateUpdateSpdQuery("spd", columnName, columnValue, jsonData);

            // WHERE koşulu için sütun adını ve değerini parametrelere ekle


            return await _connection.ExecuteAsync(updateQuery);
        }

        private async Task<string> CreateUpdateSpdQuery(string tableName, string columnName, string columnValue, JsonElement jsonData)
        {
            var expandoObject = new ExpandoObject();
            var expandoDictionary = (IDictionary<string, object>)expandoObject;

            foreach (var property in jsonData.EnumerateObject())
            {
                expandoDictionary[property.Name] = property.Value.ToString();
            }

            string updateQuery = $"UPDATE {tableName} SET ";



            foreach (var kvp in expandoDictionary)
            {
                if (kvp.Key != columnName)
                {
                    updateQuery += $"{kvp.Key} = '{kvp.Value}', ";

                }
                else
                {
                    continue;
                }
            }

            updateQuery = updateQuery.TrimEnd(',', ' ');

            updateQuery += $" WHERE {columnName} = {columnValue}";

            // Debug için ekle
            Console.WriteLine($"Update Query: {updateQuery}");

            return updateQuery;
        }

        public async Task<int> InsertSpd(JsonElement json)
        {
            string insertQuery = await CreateInsertSpdQuery("spd", json);

            return await _connection.ExecuteAsync(insertQuery);

        }

        private async Task<string> CreateInsertSpdQuery(string tableName, JsonElement jsonData)
        {
            var expandoObject = new ExpandoObject();
            var expandoDictionary = (IDictionary<string, object>)expandoObject;

            foreach (var property in jsonData.EnumerateObject())
            {
                // Sütun adını ve değeri ExpandoObject'e ekleyin2
                expandoDictionary[property.Name] = property.Value.ToString();
            }

            // Sütun adları ve değerleri için SQL sorgusunu oluştur
            string columns = string.Join(", ", expandoDictionary.Keys);
            string values = string.Join(", ", expandoDictionary.Values.Select(value => $"'{value}'"));

            // INSERT sorgusunu oluştur
            string insertQuery = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

            return insertQuery;
        }

        public async Task<IEnumerable<decimal>> GetSpdTotalSum(int srk_no, int mm_primno, int cl_primno)
        {
            string sql = $@"SELECT SUM(spd_mkt - spd_smkt_kg) AS total_sum
                              FROM spd
                              WHERE spd_srk_no = {srk_no}
                              AND spd_bcmno = 150
                              AND spd_mm_primno = {mm_primno}
                              AND spd_cl_primno = {cl_primno}
                              AND spd_bitis = 'A';
                              ";

            return await _connection.QueryAsync<decimal>(sql);
        }

        public async Task<IEnumerable<Spd>> GetSiparisDagilim(Filter? filter)
        {
            string sql = $@"  SELECT 
                                     spd.spd_birim,
                                     cmpt_spd_mkt = sum(spd_mkt),
                                     colors.cl_v5
                              FROM spd,   
                                   colors
                              WHERE (colors.cl_primno = spd.spd_tlmt_primno) and  
                                     ((spd.spd_srk_no = {filter.filterValue1} ) AND  
                                     (spd.spd_bcmno = 150 ) AND  
                                     (spd.spd_siptrh > '{filter.filterValue60?.ToString("yyyy-MM-dd")}') AND
                                     (spd.spd_siptrh < '{filter.filterValue61?.ToString("yyyy-MM-dd")}' ) AND
                                     (spd.spd_no1 = 2024 ) ) group by colors.cl_v5, spd.spd_birim;";

            return await _connection.QueryAsync<Spd, Colors,Spd>(sql, (spd, colors) =>
            {
                spd.colors = colors;
                return spd;
            },splitOn: "cmpt_spd_mkt,cl_v5");
        }

        

        public async Task<IEnumerable<Spd>> GetSpd(Filter? filter)
        {
            //string[] validParams = { "mm_kod", "mm_ad", "mm_cins", "mm_kod-mm_ad", "mm_birim", "mm_birim2", "mm_ad_ydil", "mm_tlmt_kod", "mm_brmgrp", "mm_orjkod",
            //                        "mm_grp", "mm_stokyeri", "mm_standart", "mm_des_kod", "mm_mlz_tur", "mm_alis_dvz_kod", "mm_ted_frm_kod", "mm_tas_no", "mm_grp1_kod", "mm_birim-mm_mkt_kg" };
            //string sql = "SELECT ";

            //if (validParams.Contains(filter.filterValue20))
            //{
            //    if (filter.filterValue20 == "mm_kod-mm_ad")
            //    {
            //        //(SELECT mm_ad FROM mamlz WHERE mm_primno = 44431) AS cmpt_mm_row,
            //        sql += $@" (SELECT mm_kod + ' ' + mm_ad FROM mamlz WHERE (mm_primno = {filter.filterValue2})) as cmpt_mm_row,";
            //    }
            //    else if (filter.filterValue20 == "mm_birim-mm_mkt_kg")
            //    {
            //        sql += $@" (SELECT mm_birim, mm_mkt_kg FROM mamlz WHERE mm_primno = {filter.filterValue2}) as cmpt_mm_row,";
            //    }
            //    else   
            //    {
            //        sql += $@" (SELECT {filter.filterValue20} FROM mamlz WHERE ( mm_primno = {filter.filterValue2})) as cmpt_mm_row,";
            //    }
            //}

            //sql += $@"*,
            //            cmpt_kalip_var = isnull((SELECT SUM(1) FROM colors WHERE cl_srk_no = spd.spd_srk_no AND cl_bcmno = 405 AND cl_mm_primno = spd.spd_mm_primno AND cl_islet_onay_trh IS NOT NULL AND cl_color_drm <> 10), 0)
            //          FROM spd
            //      WHERE spd.spd_sp_primno = {filter.filterValue1};
            //      ";

            //return await _connection.QueryAsync<Spd>(sql);  


            string sql = $@"select  mamlz.*,spd.*  from sp 
                            LEFT JOIN spd spd ON spd.spd_sp_primno=sp.sp_primno
                            LEFT JOIN mamlz mamlz ON mamlz.mm_primno=spd.spd_mm_primno
                            where sp_primno=130550 {filter.filterValue1};
                  ";

            return await _connection.QueryAsync<Spd>(sql);
        }



        public async Task<IEnumerable<Spd>> GetSpdFiltre(Filter? filter)
        {
            //string wherevalues = "";
            var wherevalues = new StringBuilder();
            if (!string.IsNullOrEmpty(filter.filterValue20))
            {
                wherevalues.Append($" AND spd.spd_frm_kod BETWEEN '{filter.filterValue20}' AND '{filter.filterValue21}'");
            }

            if (filter.filterValue3 != 0)
            {
                wherevalues.Append($" AND spd.spd_no1 BETWEEN {filter.filterValue3} AND {filter.filterValue4}");
            }

            if (filter.filterValue5 != 0)
            {
                wherevalues.Append($" AND spd.spd_no2 BETWEEN {filter.filterValue5} AND {filter.filterValue6}");
            }

            if (filter.filterValue5 != 0)
            {
                wherevalues.Append($" AND spd.spd_no2 BETWEEN {filter.filterValue5} AND {filter.filterValue6}");
            }

            if (!string.IsNullOrEmpty(filter.filterValue22))
            {
                wherevalues.Append($" AND spd.spd_mm_kod BETWEEN '{filter.filterValue22}' AND '{filter.filterValue23}'");
            }

            if (!string.IsNullOrEmpty(filter.filterValue26))
            {
                wherevalues.Append($" AND spd.spd_cl_kod BETWEEN '{filter.filterValue26}' AND '{filter.filterValue27}'");
            }

            if (filter.filterValue7 != 0)
            {
                wherevalues.Append($" AND spd.spd_i1 BETWEEN '{filter.filterValue7}' AND '{filter.filterValue8}'");
            }

            if (!string.IsNullOrEmpty(filter.filterValue34))
            {
                wherevalues.Append($" AND sp.sp_siptrh BETWEEN '{Convert.ToDateTime(filter.filterValue34).ToString("yyyy-MM-dd")}' AND '{Convert.ToDateTime(filter.filterValue35).ToString("yyyy-MM-dd")}'");
            }

            if (!string.IsNullOrEmpty(filter.filterValue30))
            {
                wherevalues.Append($" AND spd.spd_kartela BETWEEN '{filter.filterValue30}' AND '{filter.filterValue31}'");
            }


            string sql = $@"
                    SELECT   
                        spd.*,
                        spd.spd_smkt_kg,
                        mamlz.mm_ad,
                        mamlz.*,
                        mamlz.mm_alis_dvz_kod,
                        sp.sp_siptrh,
                        firma.frm_ksad
                    FROM spd
                    JOIN sp ON sp.sp_primno = spd.spd_sp_primno
                    JOIN firma ON firma.frm_kod = spd.spd_frm_kod
                    JOIN mamlz ON mamlz.mm_primno = spd.spd_mm_primno
                    JOIN colors ON colors.cl_primno = spd.spd_cl_primno
                    WHERE spd.spd_srk_no = {filter.filterValue1}
                        AND spd.spd_bcmno = {filter.filterValue2} {wherevalues};";

            //  AND(spd.spd_tlmt_kod = '{filter.filterValue24}' OR '{filter.filterValue25}' = 'T')
            //  AND(spd.spd_bitis = '{filter.filterValue32}' OR '{filter.filterValue33}' = 'T')

            return await _connection.QueryAsync<Spd, Mamlz, Sp, Firma, Spd>(sql, (spd, mamlz, sp, firma) =>
            {
                spd.mamlz = mamlz;
                spd.sp = sp;
                spd.firma = firma;
                return spd;
            }, splitOn: "spd_smkt_kg,mm_ad,sp_siptrh,frm_ksad");
        }


        //private async Task<string> CreateInsertQuery(string tableName, JsonElement jsonData)
        //{
        //    var expandoObject = new ExpandoObject();
        //    var expandoDictionary = (IDictionary<string, object>)expandoObject;

        //    foreach (var property in jsonData.EnumerateObject())
        //    {
        //        // Sütun adını ve değeri ExpandoObject'e ekleyin
        //        expandoDictionary[property.Name] = property.Value.ToString();
        //    }

        //    // Sütun adları ve değerleri için SQL sorgusunu oluştur
        //    string columns = string.Join(", ", expandoDictionary.Keys);
        //    string values = string.Join(", ", expandoDictionary.Values.Select(value => $"'{value}'"));

        //    // INSERT sorgusunu oluştur
        //    string insertQuery = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

        //    return insertQuery;
        //}
    }
}
