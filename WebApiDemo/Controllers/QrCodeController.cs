using Model.GoogleChartApi;
using Model.GoogleChartApi.Abstraction;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiDemo.Controllers
{
    [RoutePrefix("api/qrcode")]
    public class QrCodeController : ApiController
    {
        private IGoogleChartQrCodeBuilder qrCodeBuilder = null;
        public QrCodeController(IGoogleChartQrCodeBuilder qrCodeBuilder)
        {
            this.qrCodeBuilder = qrCodeBuilder;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get([FromUri] GoogleChartApi configuration)
        {
            var url = qrCodeBuilder.Build(configuration);

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(Request.Method, url);

                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);
                var stream = await response.Content.ReadAsStreamAsync();

                var byteArray = ReadFully(stream);

                return Request.CreateResponse(HttpStatusCode.OK, byteArray);
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[input.Length];

            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}