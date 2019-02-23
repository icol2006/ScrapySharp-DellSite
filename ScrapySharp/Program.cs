using ScrapySharp.Core;
using ScrapySharp.Html.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.Collections;
using Newtonsoft.Json;
using System.Data;

namespace ScrapySharp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ScrapingWeb scrapeWeb = new ScrapingWeb();
            DataSet dts = new DataSet();
            dts = scrapeWeb.convertToDataSet(scrapeWeb.getData());
            int s = 4;
     
        }

    }
}
