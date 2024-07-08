using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IKanbanBoardRepository : IGenericRepository<kanban_board>
    {
        Task<IEnumerable<kanban_board>> Get(string us_kod);

        Task<int> Delete(string us_kod,string srk_no);
    }
}
