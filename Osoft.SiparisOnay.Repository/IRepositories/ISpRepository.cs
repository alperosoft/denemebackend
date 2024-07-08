using Newtonsoft.Json.Linq;
using Osoft.SiparisOnay.Core.Models;
using System.Text.Json;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface ISpRepository : IGenericRepository<Sp>
    {
        Task<IEnumerable<Sp>> GetSpAll(DateTime sp_siptrh, string sp_frm_kod, int ai_srk_no);
        Task<IEnumerable<Sp>> GetSp(int srk_no, int bcmno, int no1, int no2);
        Task<IEnumerable<Sp>> GetSpProjeAll(int srk_no, string frm_kod);
        Task<IEnumerable<Spgrp>> GetSpgrpAll(int srk_no, int bcmno);
        Task<Sp> Next(int sp_srk_no, int sp_bcmno, int sp_no2,int sp_no1);
        Task<Sp> Previous(int sp_srk_no, int sp_bcmno, int sp_no2, int sp_no1);
        Task<IEnumerable<Sp>> GetList(Sp sp);

    }
}