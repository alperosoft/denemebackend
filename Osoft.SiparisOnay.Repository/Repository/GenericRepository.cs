using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.Helpers;
using Osoft.SiparisOnay.Repository.IRepositories;
using System.Data;
using Dapper;


namespace Osoft.SiparisOnay.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly IDbConnection _conn;

        public GenericRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await _conn.QueryAsync<T>(@$"SELECT * from {typeof(T).Name}")).ToList();
        }

        public async Task<IEnumerable<T>> GetByIdAsync(T entity, int id)
        {
            return await _conn.QueryAsync<T>(GenerateSql<T>.GetById(entity, id));
        }

        public async Task<int> AddAsync(T entity)
        {
            return await _conn.ExecuteScalarAsync<int>(GenerateSql<T>.Add(entity), GenerateSql<T>.Parameters(entity));
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await _conn.ExecuteAsync(GenerateSql<T>.Update(entity), GenerateSql<T>.Parameters(entity));
        }

        public async Task<int> DeleteAsync(T entity, int id)
        {
            return await _conn.ExecuteAsync(GenerateSql<T>.Detele(entity, id));
        }

        public async Task<int> DeleteAllAsync(T entity, int id, string field)
        {
            return await _conn.ExecuteAsync(GenerateSql<T>.DeleteAll(entity, id, field));
        }

        public async Task<IEnumerable<T>> GetByTableIdAsync(int srk_no, int bcmno, int yil, string table_name, string? kategori, string? f_set)
        {
            string sql;

            if (kategori is "null")
            {
                kategori = "";
            }
            if (f_set is "0" or "null")
            {
                f_set = "";
            }

            sql = @"SELECT f_id FROM table_id  Where srk_no=" + srk_no + @" and bcmno=" + bcmno + @" and yil=" + yil + @" and table_name='" + table_name + @"' and kategori='" + kategori + @"' and f_set='" + f_set + @"'";
            var result = _conn.ExecuteScalar(sql);
            if (result == null)
            {
                //table id insert
                sql = @"INSERT INTO table_id (srk_no,bcmno,yil,table_name,kategori,f_set,f_id,aciklama)  
                        VALUES (" + srk_no + @"," + bcmno + @"," + yil + @",'" + table_name + @"','" + kategori + @"','" + f_set + @"', 1,'');";
                _conn.ExecuteScalar(sql);
            }
            else
            {
                //table id update
                int sira = Convert.ToInt32(result) + 1;
                sql = @"UPDATE table_id set f_id = " + sira + @" WHERE srk_no=" + srk_no + @" and bcmno=" + bcmno + @" and yil=" + yil + @" and table_name='" + table_name + @"' and kategori='" + kategori + @"' and f_set='" + f_set + @"'";
                _conn.ExecuteScalar(sql);
            }

            sql = @"SELECT f_id FROM table_id  Where srk_no=" + srk_no + @" and bcmno=" + bcmno + @" and yil=" + yil + @" and table_name='" + table_name + @"' and kategori='" + kategori + @"' and f_set='" + f_set + @"'";
            return await _conn.QueryAsync<T>(sql);
        }

      
    }
}

