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
    [Route("api/brands/{brandId}/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CarsController(IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCarsForBrand(Guid brandId)
        {
            var brand =await _repository.Brand.GetBrandAsync(brandId, trackChanges: false);
            if (brand == null)
            {
                _logger.LogInfo($"brand with id: {brandId} doesn't exist in the database.");
            return NotFound();
            }
            var carsFromDb = _repository.Car.GetCars(brandId,trackChanges: false);
            var carsDto = _mapper.Map<IEnumerable<CarDto>>(carsFromDb);
            return Ok(carsDto);
        }
        [HttpGet("{id}", Name = "GetCarForBrand")]
        public async Task<IActionResult> GetCarForBrand(Guid brandId, Guid id)
        {
            var brand = await _repository.Brand.GetBrandAsync(brandId, trackChanges: false);
            if (brand == null)
            {
                _logger.LogInfo($"Brand with id: {brandId} doesn't exist in the database.");
                return NotFound();
            }
            var carDb = _repository.Car.GetCar(brandId, id, trackChanges:false);
            if (carDb == null)
            {
                _logger.LogInfo($"Car with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var car = _mapper.Map<CarDto>(carDb);
            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarForBrandAsync(Guid brandId, [FromBody]CarForCreationDto car)
        {
            if (car == null)
            {
                _logger.LogError("carForCreationDto object sent from client is null.");
                return BadRequest("carForCreationDto object is null");
            }
            var brand =await _repository.Brand.GetBrandAsync(brandId, trackChanges: false);
            if (brand == null)
            {
                _logger.LogInfo($"Company with id: {brandId} doesn't exist in the database.");
                return NotFound();
            }
            var carEntity = _mapper.Map<Car>(car);

            _repository.Car.CreateCarForBrand(brandId, carEntity);
           await _repository.SaveAsync();
            var carToReturn = _mapper.Map<CarDto>(carEntity);
            return CreatedAtRoute("GetCarForBrand", new{brandId,id =carToReturn.Id}, carToReturn);
        }



    }
}
