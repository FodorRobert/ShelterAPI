using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterAPI.Models;
using ShelterAPI.Models.DTOs;

namespace ShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalshelterContext _context;

        public AnimalController(AnimalshelterContext context)
        { 
            _context = context;
        }

        [HttpGet("allAnimals")]
        public object getAllAnimals()
        {
            try
            {
                var animal = _context.Animals.ToList();
                if (animal is not null)
                {
                    return StatusCode(200, new { message = "Sikeres lekérdezés", result = animal });
                }
                else
                {
                    return StatusCode(400, new { message = "Sikertelen lekérdezés", result = animal });
                }
            }
            catch (Exception exception)
            {
                return (exception.Message);
            }
        }

        [HttpPost("/animals/newAnimal")]
        public async Task<object> AddNewAnimal([FromBody] AddNewAnimalDTOs add)
        {
            try
            {
                var animal = new Animal
                {
                    Id = Guid.NewGuid(),
                    Name = add.Name,
                    Species = add.Species,
                    Age = add.Age,
                    Weight = add.Weight,
                    RegTime = DateTime.Now
                };
                if (animal is not null)
                {
                    await _context.Animals.AddAsync(animal);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, new { message = "Sikeres felvétel", result = animal });
                }
                return StatusCode(400, new { message = "Sikertelen felvétel", result = animal });
            }
            catch (Exception exception)
            {
                return (exception.Message);
            }
        }
    }
}
