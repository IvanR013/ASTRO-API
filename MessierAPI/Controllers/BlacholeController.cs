using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MessierAPI.Models; // Add this line if MessierModel is defined in the Models namespace


namespace MessierAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BlackholeController : ControllerBase
{
    private readonly List<BlackHoleModel> _messier;

    public BlackholeController()
    {
        var jsonData = Path.Combine(Directory.GetCurrentDirectory(), "Data", "BlackHole.json");
        _messier = JsonConvert.DeserializeObject<List<BlackHoleModel>>(System.IO.File.ReadAllText(jsonData)) ?? new List<BlackHoleModel>();
    }


    [HttpGet("Data")]
    public IActionResult GetBlackholeObjects()
    {
        if (!_messier.Any()) return NotFound(new { message = "No se encontraron datos." });

        return Ok(new { Status = "Success", Data = _messier });
    }

    [HttpGet("{tipo}")]
    public IActionResult GetBlackholeObject(string tipo)
    {
        BlackHoleModel? Objeto = _messier.FirstOrDefault(n => n.Tipo.ToLower() == tipo.ToLower());

        if (Objeto is null) return NotFound(new { message = "No se encontraron datos." });

        return Ok(new { Status = "Success", Data = Objeto });
    }

}



