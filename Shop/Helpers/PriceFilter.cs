using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Helpers
{
    public class PriceFilter : IFilter
    {
        public float MaxAvaliblePrice { get; set; }
        public float MinAvaliblePrice { get; set; }
        public float MaxPrice { get; set; }
        public float MinPrice { get; set; }
    }
}
