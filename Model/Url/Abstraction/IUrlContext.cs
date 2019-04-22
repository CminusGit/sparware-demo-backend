using Model.Url;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Url.Context
{
    public interface IUrlContext
    {
        Task<IEnumerable<UrlModel>> GetUrls();
    }
}
