using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class CarsParameters : RequestParameters
    {
        public CarsParameters()
        {
            OrderBy = "name";
        }
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = int.MaxValue; 
        public bool ValidPriceRange => MaxPrice > MinPrice;
        public string Search { get; set; } 
    }
}
