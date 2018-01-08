using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}