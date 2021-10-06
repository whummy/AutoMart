using AutoMapper;
using AutoMart.ActionFilters;
using AutoMart.ModelBinders;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMart.Controllers
{
    [Route("api/v1/brands")]
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

        /// <summary>
        /// Gets the list of all brands
        /// </summary>
        /// <returns>The brands list</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBrands([FromQuery] BrandParameters brandParameters)
        {            
            var brandsFromDb = await _repository.Brand.GetAllBrandsAsync(brandParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(brandsFromDb.MetaData));

            var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brandsFromDb);

            return Ok(brandsDto);
        }

        /// <summary>
        /// Gets a brand with Id
        /// </summary>
        /// <returns>A brand</returns>
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

        [HttpGet("collection/({ids})", Name = "BrandCollection")]
        public async Task<IActionResult> GetBrandCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var brandEntities = await _repository.Brand.GetByIdsAsync(ids, trackChanges:false);
            if (ids.Count() != brandEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }
            var brandsToReturn = _mapper.Map<IEnumerable<BrandDto>>(brandEntities);
            return Ok(brandsToReturn);
        }

        /// <summary>
        /// Creates a new brand
        /// </summary>
        /// <returns>A new brand</returns>
        [HttpPost, Authorize]
        public async Task<IActionResult> Createbrand([FromRoute] string Token, [FromBody] BrandForCreationDto brand)
        {
            if (brand == null)
            {
                _logger.LogError("BrandForCreationDto object sent from client is null.");
                return BadRequest("BrandForCreationDto object is null");
            }
            var brandEntity = _mapper.Map<Brand>(brand);

            _repository.Brand.CreateBrand(Token, brandEntity);
            await _repository.SaveAsync();

            var brandToReturn = _mapper.Map<BrandDto>(brandEntity);
            return CreatedAtRoute("BrandById", new { id = brandToReturn.Id },brandToReturn);
        }

        /// <summary>
        /// Creates a new brand collection
        /// </summary>
        /// <returns>A new brand collection</returns>
        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromRoute] String Token, [FromBody]IEnumerable<BrandForCreationDto> brandCollection)
        {
            if (brandCollection == null)
            {
                _logger.LogError("brand collection sent from client is null.");
                return BadRequest("brand collection is null");
            }
            var brandEntities = _mapper.Map<IEnumerable<Brand>>(brandCollection);
            foreach (var brand in brandEntities)
            {
                _repository.Brand.CreateBrand(Token, brand);
            }
            await _repository.SaveAsync();
            var brandCollectionToReturn =
            _mapper.Map<IEnumerable<BrandDto>>(brandEntities);
            var ids = string.Join(",", brandCollectionToReturn.Select(b => b.Id));
            return CreatedAtRoute("BrandCollection", new { ids },brandCollectionToReturn);
        }

        /// <summary>
        /// Deletes a brand by Id
        /// </summary>
        /// <returns>Delete a brand by Id</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(Guid id)
        {
            var brand = await _repository.Brand.GetBrandAsync(id, trackChanges: false);
            if (brand == null)
            {
                _logger.LogInfo($"Brand with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Brand.DeleteBrand(brand);
            await _repository.SaveAsync();
            return NoContent();
        }
        /// <summary>
        /// Updates a brand with Id
        /// </summary>
        /// <returns>Updates a brand</returns>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateBrand(Guid id, [FromBody] BrandForUpdateDto brand)
        {
            if (brand == null)
            {
                _logger.LogError("BrandForUpdateDto object sent from client is null.");
                return BadRequest("BrandForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the BrandForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var brandEntity = await _repository.Brand.GetBrandAsync(id, trackChanges:
           true);
            if (brandEntity == null)
            {
                _logger.LogInfo($"Brand with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(brand, brandEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

    }
}
