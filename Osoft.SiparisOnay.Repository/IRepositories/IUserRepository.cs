using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> UserAll(int srk_no);
        Task<IEnumerable<User>> UserLogin(Filter filter);
        
    }
}
