using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        // Navigation Properties
        public ICollection<Car> Cars { get; set; }

    }
}
