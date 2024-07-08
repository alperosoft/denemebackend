using Osoft.SiparisOnay.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IColorsRepository : IGenericRepository<Colors>
    {
        Task<IEnumerable<Colors>> GetGelenRenk(Filter? filter);
        Task<IEnumerable<Colors>> GetOnayRenk(Filter? filter);
        Task<IEnumerable<Colors>> GetColorsAll(int srk_no, int bcmno);
        Task<IEnumerable<Colors>> GetColorAll(int srk_no, int bcmno, int tur);
        Task<IEnumerable<Colors>> GetColor(int srk_no, int cl_primno);
        Task<IEnumerable<Colors>> GetColorsYardim(Filter? filter);
    }
}
