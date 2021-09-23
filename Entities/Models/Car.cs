﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Car
    {
        [Column("CarId")]
        public Guid Id { get; set; }
        public string ModelName { get; set; }
        public string Colour { get; set; }
        public string Describtion { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Condition { get; set; }
        public string BodyType { get; set; }
        public Guid BrandId { get; set; }
        public Guid? UserId { get; set; }
        // Navigation Properties
        public Brand Brand { get; set; }




    }
}
