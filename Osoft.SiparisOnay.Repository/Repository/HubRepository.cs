using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using System.Data;
using System.Data.Odbc;
using System.Security.Cryptography;
using System.Text;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class MyHub : Hub { }

    public class HubRepository : IHubRepository
    {

        private readonly string connectionString;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly IMapper _mapper;
        private readonly IHubRepository _totalRepository;
        private readonly IReceteRepository _receteRepository;
        private readonly ISpwoRepository _spwoRepository;
        private readonly ISevkiyatRepository _sevkiyatRepository;
        private readonly IStkfdRepository _stkfdRepository;
        private readonly IColorsRepository _colorsRepository;
        private readonly IConfiguration _configuration;





        public HubRepository(IConfiguration configuration, IHubContext<MyHub> hubContext, IMapper mapper, IReceteRepository receteRepository, ISpwoRepository spwoRepository, ISevkiyatRepository sevkiyatRepository, IStkfdRepository stkfdRepository, IColorsRepository colorsRepository)
        {
            _hubContext = hubContext;
            _mapper = mapper;
            _receteRepository = receteRepository;
            _spwoRepository = spwoRepository;
            _sevkiyatRepository = sevkiyatRepository;
            _stkfdRepository = stkfdRepository;
            _colorsRepository = colorsRepository;
            _configuration = configuration;
        }

        public async Task RunUserSpecificJob(Filter? filter)
        {
            string dsn = _configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            string user = _configuration.GetSection("ConnectionStrings")["User"];
            string cryptedString = _configuration.GetSection("ConnectionStrings")["Password"];

            if (string.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("Password is empty.");
            }

            byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            string password = reader.ReadToEnd();

            string connectionString = $"Dsn={dsn};Uid={user};Pwd={password}";


            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                await connection.OpenAsync();

                string jobName = $"UserSpecificJob_{filter.filterValue21}";


                #region ReceteSQL

                IEnumerable<Recete> receteData = await _receteRepository.GetRecete(filter);

                #endregion

                #region UretimSQL

                IEnumerable<Spwo> uretimData = await _spwoRepository.GetUretim(filter);

                #endregion

                #region SevkiyatFasonSql

                filter.filterValue20 = "F";

                IEnumerable<Spkateg> sevkiyatFasonData = await _sevkiyatRepository.GetSevkiyat(filter);

                #endregion

                #region SevkiyatSatisSql

                filter.filterValue20 = "S";

                IEnumerable<Spkateg> sevkiyatSatisData = await _sevkiyatRepository.GetSevkiyat(filter);

                #endregion

                #region GelenUrunSQL

                IEnumerable<Stkfd> gelenUrunData = await _stkfdRepository.GetGelenUrun(filter);

                #endregion

                #region GelenRenkSQL

                IEnumerable<Colors> gelenRenkData = await _colorsRepository.GetGelenRenk(filter);
                #endregion

                #region OnayRenkSQL

                IEnumerable<Colors> onayRenkData = await _colorsRepository.GetGelenRenk(filter);

                #endregion


                var combinedData = new CombinedDataDTO
                {
                    ReceteDTO = receteData.Select(hero => _mapper.Map<ReceteDTO>(hero)),
                    SpwoUretimDTO = uretimData.Select(hero => _mapper.Map<SpwoUretimDTO>(hero)),
                    SevkiyatFasonDTO = sevkiyatFasonData.GroupBy(item => item.spkategCmpt.cmpt_text)
                                                        .Select(group => new SevkiyatDTO
                                                        {
                                                            cmpt_text = group.Key,
                                                            total_cmpt_bmkt_kg = group.Sum(item => item.spkategCmpt.cmpt_bmkt_kg),
                                                            total_cmpt_mkt_kg = group.Sum(item => item.spkategCmpt.cmpt_mkt_kg),
                                                        }),
                    SevkiyatSatisDTO = sevkiyatSatisData.GroupBy(item => item.spkategCmpt.cmpt_text)
                                                        .Select(group => new SevkiyatDTO
                                                        {
                                                            cmpt_text = group.Key,
                                                            total_cmpt_bmkt_kg = group.Sum(item => item.spkategCmpt.cmpt_bmkt_kg),
                                                            total_cmpt_mkt_kg = group.Sum(item => item.spkategCmpt.cmpt_mkt_kg),
                                                        }),
                    StkfdGelenUrunDTO = gelenUrunData.GroupBy(item => item.depo.dp_ad)
                                          .Select(group => new StkfdGelenUrunDTO
                                          {
                                              dp_ad = group.Key,
                                              total_fason_kg = group.Sum(item => item.sfd_fist_no == 11 ? item.stkfdCmpt.cmpt_kg : 0),
                                              total_satin_alim_kg = group.Sum(item => item.sfd_fist_no == 10 ? item.stkfdCmpt.cmpt_kg : 0),
                                          }),
                    GelenRenkDTO = gelenRenkData.Select(hero => _mapper.Map<GelenRenkDTO>(hero)),
                    OnayRenkDTO = onayRenkData.Select(hero => _mapper.Map<OnayRenkDTO>(hero)),
                };

                await _hubContext.Clients.All.SendAsync(jobName, combinedData);
            }
        }
    }
}
