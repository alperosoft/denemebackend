using Osoft.SiparisOnay.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IIsletmeRepository : IGenericRepository<Isletme>
    {
        Task<IEnumerable<Isletme>> GetIsletmeAll();
    }
}
