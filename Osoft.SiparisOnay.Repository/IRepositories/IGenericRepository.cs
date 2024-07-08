namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByIdAsync(T entity, int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity, int id);
        Task<int> DeleteAllAsync(T entity, int id,string field);
        Task<IEnumerable<T>> GetByTableIdAsync(int srk_no, int bcmno, int yil, string table_name, string? kategori, string? f_set);
    }
}