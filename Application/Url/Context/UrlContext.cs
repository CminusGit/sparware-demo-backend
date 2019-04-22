using Model.Url;
using Persistence.Url;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Application.Url.Context
{
    public class UrlContext : IUrlContext
    {
        private IUrlRepository repository = null;

        public UrlContext(IUrlRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<UrlModel>> GetUrls()
        {
            return await this.repository.GetUrls();
        }
    }
}
