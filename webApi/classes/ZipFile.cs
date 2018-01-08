using System;
using System.IO;
using System.IO.Compression;

namespace webApi.classes
{
    public class ZipFile
    {
        public static void Descompactar(Stream arquivo)
        {
            using (ZipArchive archive = new ZipArchive(arquivo))
            {
               // archive.ExtractToDirectory(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/"));
               foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    var stream = entry.Open();
                    //Do awesome stream stuff!!                 
                }
            }    
        }
    }

}