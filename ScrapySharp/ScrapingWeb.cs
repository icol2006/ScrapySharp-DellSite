using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapySharp
{
    public class ScrapingWeb
    {
        public static DataTable loadDatatableColumns()
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt.Columns.Add("Category");
            dt.Columns.Add("Type");
            dt.Columns.Add("Description");
            dt.Columns.Add("Importance");
            dt.Columns.Add("Version");
            dt.Columns.Add("Released");
            dt.Columns.Add("Supported OS");
            // dt.Columns.Add("Download");

            return dt;
        }

        public DataSet convertToDataSet(List<Category> listCategories)
        {
            DataSet dts = new DataSet();
            DataTable dt = loadDatatableColumns();
            DataRow dtr = dt.NewRow();

            foreach (var category in listCategories)
            {                

                foreach (var listType in category.ListTypes)
                {
                    for (int i = 1; i < listType.listProducts.Count(); i++)
                    {
                        Product product = listType.listProducts[i];
                        dtr["Category"] = category.Name;
                        dtr["Type"] = listType.Name;
                        dtr["Description"] = product.Description;
                        dtr["Importance"] = product.Importance;
                        dtr["Version"] = product.Version;
                        dtr["Released"] = product.Release;
                        dtr["Supported OS"] = product.SupportedOs;
                        //dtr["Download"] = product.DownloadLink;
                        dt.Rows.Add(dtr.ItemArray);
                        dtr = dt.NewRow();
                    }
                    dts.Tables.Add(dt);
                    dt = loadDatatableColumns();
                }
                
              
            }

            return dts;
        }

        public List<Category> getData()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://downloads.dell.com/published/pages/alienware-alpha.html");
            List<Category> listCategories = new List<Category>();
            List<Type> listTypes = new List<Type>();
            List<Product> listProduct = new List<Product>();

            Type type = new Type();
            Product product = new Product();
            Category category = new Category();

            var nodes = doc.DocumentNode.CssSelect("#Drivers>UL>LI").ToList();
            foreach (var node in nodes)
            {
                category.Name = node.CssSelect("H5").FirstOrDefault().InnerText.Replace("Category:", "");

                var infoListTypes = node.CssSelect("ul>li");
                var nameType = node.CssSelect("ul>li>h5").ToList();


                foreach (var infoType in infoListTypes)
                {

                    type.Name = infoType.CssSelect("H5").FirstOrDefault().InnerText.Replace("Type:", "");

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
                            DataTable dd;

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

            return listCategories;
        }
    }
}
