﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcarsbycoloridwithdetails")]
        public IActionResult GetCarsByColorIdWithDetails(int colorId)
        {
            var result = _carService.GetCarsByColorIdWithDetails(colorId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcarsbybrandidwithdetails")]
        public IActionResult GetCarsByBrandIdWithDetails(int brandId)
        {
            var result = _carService.GetCarsByBrandIdWithDetails(brandId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcarsbycolorandbrand")]
        public IActionResult GetCarsByColorAndBrand(int colorId, int brandId)
        {
            var result = _carService.GetCarsByColorAndBrand(colorId, brandId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }





        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
