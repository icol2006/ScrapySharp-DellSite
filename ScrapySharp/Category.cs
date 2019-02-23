using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapySharp
{
    public class Category
    {
        public String Name { get; set; }
        public List<Type> ListTypes { get; set; }

        public Category()
        {
            ListTypes = new List<Type>();
        }
    }
}
