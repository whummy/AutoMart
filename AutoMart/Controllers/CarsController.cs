using AutoMapper;
using AutoMart.ActionFilters;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMart.Controllers
{
    [Route("api/v1/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CarsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of all carss
        /// </summary>
        /// <returns>The cars list</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCarByBrand(Guid brandId,[FromQuery] CarsParameters carParameters)
        {
            if (!carParameters.ValidPriceRange)
                return BadRequest("Max age can't be less than min age.");
            var carsFromDb = await _repository.Car.GetCarsAsync(brandId, carParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(carsFromDb.MetaData));

            var carsDto = _mapper.Map<IEnumerable<CarDto>>(carsFromDb);
            return Ok(carsDto);
        }

        /// <summary>
        /// Gets a Car with Id
        /// </summary>
        /// <returns>A car</returns>
        [HttpGet("{id}", Name = "GetCarForBrand")]
        public async Task<IActionResult> GetCar(Guid id)
        {
            var carDb = await _repository.Car.GetCarAsync(id, trackChanges:false);
            if (carDb == null)
            {
                _logger.LogInfo($"Car with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var car = _mapper.Map<CarDto>(carDb);
            return Ok(car);
        }

        /// <summary>
        /// Creates a new car
        /// </summary>
        /// <returns>A new car</returns>
        [HttpPost]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCarAsync([FromBody]CarForCreationDto car)
        {
            if (car == null)
            {
                _logger.LogError("carForCreationDto object sent from client is null.");
                return BadRequest("carForCreationDto object is null");
            }
            var brand =await _repository.Brand.GetBrandAsync(car.brandId, trackChanges: false);
            if (brand == null)
            {
                var error = $"Brand with id: {car.brandId} doesn't exist in the database.";
                _logger.LogInfo(error);
                return BadRequest(error);
            }

            var carEntity = _mapper.Map<Car>(car);


            _repository.Car.CreateCar(carEntity);
            await _repository.SaveAsync();
            var carToReturn = _mapper.Map<CarDto>(carEntity);

            return CreatedAtRoute("GetCarForBrand", new{id =carToReturn.Id}, carToReturn);
        }

        /// <summary>
        /// Deletes a car by Id
        /// </summary>
        /// <returns>Delete a car by Id</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarForBrand(Guid id)
        {
            var carForBrand = await _repository.Car.GetCarAsync(id, trackChanges: false);
            if (carForBrand == null)
            {
                _logger.LogInfo($"Car with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Car.DeleteCar(carForBrand);
            await _repository.SaveAsync();
            return NoContent();
        }

        /// <summary>
        /// Updates a car with Id
        /// </summary>
        /// <returns>Updates a car</returns>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateCar(Guid brandId, Guid id, [FromBody]CarForUpdateDto car)
        {
            if (car == null)
            {
                _logger.LogError("CarForUpdateDto object sent from client is null.");
                return BadRequest("CarForUpdateDto object is null");
            }
            var brand = _repository.Brand.GetBrandAsync(brandId, trackChanges: false);
            if (brand == null)
            {
                _logger.LogInfo($"Brand with id: {brandId} doesn't exist in the database.");
                return NotFound();
            }
            var carEntity = _repository.Car.GetCarAsync(id, trackChanges:true);
            if (carEntity == null)
            {
                _logger.LogInfo($"Car with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(car, carEntity);
            _repository.SaveAsync();
            return NoContent();
        }
    }
}
