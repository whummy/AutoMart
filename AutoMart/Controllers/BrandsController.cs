using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMart.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public BrandsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {            
            var brands =await _repository.Brand.GetAllBrandsAsync(trackChanges: false);
            var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);

            return Ok(brandsDto);
        }
        [HttpGet("{id}", Name = "BrandById")]
        public async Task<IActionResult> GetBrand(Guid id)
        {
            var brand =await _repository.Brand.GetBrandAsync(id, trackChanges: false);
            if (brand == null)
            {
                _logger.LogInfo($"Brand with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var brandDto = _mapper.Map<BrandDto>(brand);
                return Ok(brandDto);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Createbrand([FromBody] BrandForCreationDto brand)
        {
            if (brand == null)
            {
                _logger.LogError("BrandForCreationDto object sent from client is null.");
                return BadRequest("BrandForCreationDto object is null");
            }
            var brandEntity = _mapper.Map<Brand>(brand);
            _repository.Brand.CreateBrand(brandEntity);
            await _repository.SaveAsync();
            var brandToReturn = _mapper.Map<BrandDto>(brandEntity);
            return CreatedAtRoute("BrandById", new { id = brandToReturn.Id },brandToReturn);
        }


    }
}
