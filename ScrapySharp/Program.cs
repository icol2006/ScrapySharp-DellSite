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

namespace ScrapySharp
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://downloads.dell.com/published/pages/alienware-alpha.html");
            List<Category> listCategories = new List<Category>();
            List<Type> listTypes = new List<Type>();
            List<Product> listProduct = new List<Product>();

            Type type = new Type();
            Product product = new Product();
            Category category = new Category();

            ArrayList dataDescription = new ArrayList();
            ArrayList dataTemp = new ArrayList();
            //var page = doc.DocumentNode.CssSelect("//body");

            //  var nodes = doc.DocumentNode.CssSelect("#item-search-results li").ToList();
            var nodes = doc.DocumentNode.CssSelect("#Drivers>UL>LI").ToList();
            foreach (var node in nodes)
            {

                category.Name=doc.DocumentNode.CssSelect("H5").FirstOrDefault().InnerText;

                var infoListTypes = node.CssSelect("ul>li");
                var nameType= node.CssSelect("ul>li>h5").ToList();              
                

                foreach (var infoType in infoListTypes)
                {
                  
                    type.Name= infoType.CssSelect("H5").FirstOrDefault().InnerText;
                  
                    var infoListProduct = infoType.CssSelect("tr").ToList();

                    foreach (var infoProduct in infoListProduct)
                    {
                        var info = infoProduct.CssSelect("td");

                        for (int i = 0; i <= info.Count(); i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    product.Description = info.ElementAt(i).InnerText;
                                    break;
                                case 1:
                                    product.Importance = info.ElementAt(i).InnerText;
                                    break;
                                case 2:
                                    product.Version = info.ElementAt(i).InnerText;
                                    break;
                                case 3:
                                    product.Release = info.ElementAt(i).InnerText;
                                    break;
                                case 4:
                                    product.SupportedOs = info.ElementAt(i).InnerText;
                                    break;
                                case 5:
                                    product.DownloadLink = info.ElementAt(i).InnerText;
                                    break;
                                default:
                                    break;
                            }


                        }
                        type.listProducts.Add(product);
                    
                        product = new Product();
                    }

                    category.ListTypes.Add(type);
                    type = new Type();
                }

                listCategories.Add(category);
                category = new Category();

             
            }

            String result = JsonConvert.SerializeObject(listCategories);

            Console.ReadLine();
        }
    }
}
