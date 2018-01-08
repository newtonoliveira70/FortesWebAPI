using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace webApi.Models
{
    public class Upload : ApiController

        [HttpPost]
        public async Task<HttpResponseMessage> Upload()
        {
            string MyString = "";
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];


                    int FileLen = postedFile.ContentLength;
                    byte[] input = new byte[FileLen];

                    // Initialize the stream.
                    System.IO.Stream MyStream = postedFile.InputStream;

                    StreamReader reader = new StreamReader(MyStream);
                    string texto = reader.ReadToEnd();

                    /*
                    Salvar o arquivo no servidor
                    var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("\\") + 1));

                    docfiles.Add(filePath);
                    */
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }
}