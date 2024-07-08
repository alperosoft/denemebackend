using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories;

public interface IStkfdTopRepository : IGenericRepository<stkfdtop>
{
    Task<IEnumerable<stkfdtop>> Find(int sfd_srk_no, int sfd_bcmno, int sfd_sf_primno);
}