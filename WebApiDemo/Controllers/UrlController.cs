using Application.Url.Context;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiDemo.Controllers
{
    [RoutePrefix("api/url")]
    public class UrlController : ApiController
    {
        private IUrlContext context = null;

        public UrlController(IUrlContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var urls = await this.context.GetUrls();

            return Ok(urls);
        }
    }
}