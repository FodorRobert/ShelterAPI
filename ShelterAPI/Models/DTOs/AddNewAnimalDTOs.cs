using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShelterAPI.Models.DTOs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewAnimalDTOs : ControllerBase
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Species { get; set; }

        public int? Age { get; set; }

        public double? Weight { get; set; }

        public DateTime? RegTime { get; set; }
    }
}
