using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using webApi.Models;

namespace webApi.Controllers
{
    public class FileMinMaxController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Upload()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string linha = "";
            HttpResponseMessage result = null;
            if (UploadFile.executar(HttpContext.Current.Request, Request, ref linha, ref result))
            {
                var docfiles = new List<string>();
                if (MinMaxSoma.calcular(linha, docfiles))
                {
                    result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest, docfiles);
                }
            }
            stopwatch.Stop();
            ReturnoHub.SendMessage(stopwatch.Elapsed.ToString());
            return result;
        }
    }
}
