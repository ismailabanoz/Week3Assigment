using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Data.Models
{
    public class ProductFullModel :IEntity
    {
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
