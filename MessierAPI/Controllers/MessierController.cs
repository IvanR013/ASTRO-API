using MessierAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace MessierAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessierController : ControllerBase
    {
        private readonly List<MessierModel> _messier;
        public MessierController()
        {
            var JsonData = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Messier.json");
            _messier = JsonConvert.DeserializeObject<List<MessierModel>>(System.IO.File.ReadAllText(JsonData)) ?? new List<MessierModel>();
        }

//General Delivery data.
        [HttpGet("Data")]
        public IActionResult GetMessierObjects()
        {
            if (!_messier.Any())
            {
                return NotFound(new { message = "No se encontraron datos." });
            }

            return Ok(new { Status = "Success", Data = _messier });
        }

//This endpoint tracks with a type filter.
        [HttpGet("{tipo}")]
        public IActionResult GetMessierObject(string tipo)
        {
            var Objeto = _messier.FirstOrDefault(n => n.Tipo.ToLower() == tipo.ToLower());

            if (Objeto == null)
            {
                return NotFound(new { message = "No se encontraron datos." });
            }

            return Ok(new { Status = "Success", Data = Objeto });
        }

    }
}
