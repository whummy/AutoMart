﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class BrandCollectionDto
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}
