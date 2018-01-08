using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using webApi.classes;

namespace webApi.Models
{
    public class UploadFile
    {
        public static bool executar(HttpRequest request, HttpRequestMessage requestMessage, ref String linha, ref HttpResponseMessage result)
        {
            bool retorno = false;
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

                    //ZipFile.Descompactar(MyStream);

                    StreamReader reader = new StreamReader(MyStream);
                    linha = reader.ReadToEnd();
                }
                retorno = true;
            }
            else
            {
                result = requestMessage.CreateResponse(HttpStatusCode.BadRequest);
            }
            return retorno;
        }
    }
}