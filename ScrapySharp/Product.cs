using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapySharp
{
    public class Product
    {
        public String Description { get; set; }
        public String Importance { get; set; }
        public String Version { get; set; }
        public String Release { get; set; }
        public String SupportedOs { get; set; }
        public String DownloadLink { get; set; }
    }
}
