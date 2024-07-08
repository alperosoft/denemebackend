using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<MenuNew>> GetMenuNew(Filter? filter);

        Task<IEnumerable<menu_new_yetki2>> GetMenuNewYetki(Filter? filter);

        Task<IEnumerable<MenuNew>> GetAllMenuNew();
    }
}
