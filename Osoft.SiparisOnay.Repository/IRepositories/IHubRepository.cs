    using Osoft.SiparisOnay.Core.Models;

    namespace Osoft.SiparisOnay.Repository.IRepositories
    {
        public interface IHubRepository 
        {
            Task RunUserSpecificJob(Filter? filter);
        }
    }
