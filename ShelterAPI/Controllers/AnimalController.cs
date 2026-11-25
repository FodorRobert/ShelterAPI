using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterAPI.Models;

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
    }
}
