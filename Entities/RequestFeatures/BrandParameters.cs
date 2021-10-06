using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class BrandParameters : RequestParameters
    {
        public BrandParameters()
        {
            OrderBy = "name";
        }
        public string Search { get; set; }
    }
}
