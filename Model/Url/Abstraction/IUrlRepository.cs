using Model.Url;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Url
{
    public interface IUrlRepository
    {
        Task<IEnumerable<UrlModel>> GetUrls();
    }
}
