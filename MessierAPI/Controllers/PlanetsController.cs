using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MessierAPI.Models;

namespace MessierAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PlanetsController : ControllerBase
    {
        private readonly List<PlanetsModel> _planets;

        public PlanetsController()
        {
            var JsonData = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Planets.json");
            _planets = JsonConvert.DeserializeObject<List<PlanetsModel>>(System.IO.File.ReadAllText(JsonData)) ?? new List<PlanetsModel>();
        }

        [HttpGet("Data")]
        public IActionResult GetPlanets()
        {
            if (!_planets.Any())
            {
                return NotFound(new { message = "No se encontraron datos." });
            }

            return Ok(new { Status = "Success", Data = _planets });
        }

        [HttpGet("{tipo}")]
        public IActionResult GetType(string tipo)
        {
            var Objeto = _planets.FirstOrDefault(n => n.Tipo.ToLower() == tipo.ToLower());

            if (Objeto == null)
            {
                return NotFound(new { message = "No se encontraron datos." });
            }

            return Ok(new { Status = "Success", Data = Objeto });
        }
    }

}