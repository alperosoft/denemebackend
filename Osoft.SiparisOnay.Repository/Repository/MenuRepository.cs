using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class MenuRepository : GenericRepository<MenuNew>, IMenuRepository
    {
        private readonly IDbConnection _connection;

        public MenuRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<MenuNew>> GetMenuNew(Filter? filter)
        {
            string sql = $@"
                             select * from menu_new  where mnew_bcmno=66";

            return await _connection.QueryAsync<MenuNew>(sql);
            //sql += " ORDER BY menu_new.mnew_kod1";
            //return await _connection.QueryAsync<MenuNew, MenuNewYetki, MenuNew>(sql, (menuNew, menuNewYetki) =>
            //{
            //    menuNew.menuNewYetki = menuNewYetki;
            //    return menuNew;

            //}, splitOn: "mnew_sira3,meny_id");
        }

        public async Task<IEnumerable<menu_new_yetki2>> GetMenuNewYetki(Filter? filter)
        {
            //string sql = $@"    SELECT DISTINCT mnew_sira,mnew_sira2,
            //                           meny2_mnew_id,
            //                           meny2_kod1,
            //                           meny2_kod2,
            //                           meny2_kod3
            //                    FROM menu_new_yetki,   
            //                         menu_new, menu_new_yetki2  
            //                    WHERE (  menu_new.mnew_id = menu_new_yetki.meny_mnew_id ) AND  
            //                          (  menu_new_yetki2.meny2_mnew_id = menu_new_yetki.meny_mnew_id ) AND
            //                          (  menu_new_yetki.meny_us_kod = '{filter.filterValue21}' ) AND menu_new.mnew_srk_no='{filter.filterValue1}'
            //                    ORDER BY mnew_sira,  mnew_sira2";

            string sql = $@"    SELECT DISTINCT mnew_sira,mnew_sira2,
                                       mnew_url,
                                       mnew_resim1,
                                       meny2_mnew_id,
                                       meny2_kod1,
                                       meny2_kod2,
                                       meny2_kod3
                                FROM menu_new_yetki,   
                                     menu_new, menu_new_yetki2  
                                WHERE (  menu_new.mnew_id = menu_new_yetki.meny_mnew_id ) AND  
                                      (  menu_new_yetki2.meny2_mnew_id = menu_new_yetki.meny_mnew_id ) AND
                                      (  menu_new_yetki.meny_us_kod = 'PLAN2' ) AND menu_new.mnew_srk_no='{filter.filterValue1}'
                                ORDER BY mnew_sira,  mnew_sira2";

            return await _connection.QueryAsync<MenuNew, menu_new_yetki2, menu_new_yetki2>(sql, (menuNew, menu_new_yetki2) =>
            {
                menu_new_yetki2.menuNew = menuNew;
                return menu_new_yetki2;

            }, splitOn: "mnew_resim1,meny2_mnew_id");

            //return await _connection.QueryAsync<menu_new_yetki2>(sql);
        }

        public async Task<IEnumerable<MenuNew>> GetAllMenuNew()
        {
            // string sql = $@"SELECT * FROM menu_new where mnew_kod2='Genel Tanıtımlar' ORDER BY mnew_kod1 asc";
            string sql = $@"SELECT * FROM menu_new   ORDER BY mnew_kod1 asc";
            return await _connection.QueryAsync<MenuNew>(sql);
        }
    }
}
