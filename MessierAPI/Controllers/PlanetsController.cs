using Microsoft.AspNetCore.Mvc;
using MessierAPI.Repositories;
using MessierAPI.Models;
using MessierAPI.Exceptions;

namespace MessierAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PlanetsController : ControllerBase
{
    private readonly IJsonDataRep _objects;

    public PlanetsController(IJsonDataRep objects) => this._objects = objects;


    [HttpGet("Data")]
    public IActionResult GetPlanets()
    {
        try
        {
            List<PlanetsModel>? PlanetObjects = _objects.GetPlanets();

            if (PlanetObjects is null) return BadRequest(new { message = "No se encontraron datos." });

            return Ok(new { Status = "Success", Data = PlanetObjects });
        }
        catch (DataNotFoundException err)
        {
            return StatusCode(500, new { Error = "hubo un error al encontrar datos.", err });
        }
    }

    [HttpGet("{tipo}")]
    public IActionResult GetType(string tipo)
    {
        try
        {
            List<PlanetsModel>? PlanetObject = _objects.GetPlanets(tipo);
            if (PlanetObject is null) return NotFound(new { message = "No se encontraron datos." });

            return Ok(new { Status = "Success", Data = PlanetObject });
        }
        catch (DataNotFoundException err)
        {
            return StatusCode(500, new { Error = "hubo un error al encontrar datos.", err });
        }

    }
}







