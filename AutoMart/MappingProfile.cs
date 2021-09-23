using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMart
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<Car, CarDto>();
            CreateMap<BrandForCreationDto, Brand>();
            CreateMap<CarForCreationDto, Car>();

        }

    }
}
