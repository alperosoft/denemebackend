using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IFirmagrpRepository : IGenericRepository<Firmagrp>
    {
        Task<IEnumerable<Firmagrp>> FirmagrpAll(int srk_no);
    }
}
