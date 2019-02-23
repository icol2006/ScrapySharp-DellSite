using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapySharp
{
    public class Type
    {
        public String Name { get; set; }
        public List<Product> listProducts { get; set; }

        public Type()
        {
            listProducts = new List<Product>();
        }
    }
}
