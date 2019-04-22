using Model.Url;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Persistence.Url
{
    public class UrlRepository : IUrlRepository
    {
        public async Task<IEnumerable<UrlModel>> GetUrls()
        {
            JsonSerializer serializer = new JsonSerializer();

            var root = Directory.GetParent(HostingEnvironment.ApplicationPhysicalPath).Parent.FullName;
            var path = Path.Combine((root), @"Persistence\DB\DB.json");

            using (var reader = new StreamReader(path))
            {
                string json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<IEnumerable<UrlModel>>(json);
            }
        }
    }
}
