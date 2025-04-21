using Microsoft.AspNetCore.Mvc;
using MessierAPI.Repositories;
using MessierAPI.Models; // Add this line if MessierModel is defined in the Models namespace
using MessierAPI.Exceptions;

namespace MessierAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BlackholeController : ControllerBase
{
    private readonly IJsonDataRep _objects;

    public BlackholeController(IJsonDataRep objects) => this._objects = objects;



    [HttpGet("Data")]
    public IActionResult GetBlackholeObjects()
    {
        try
        {
            List<BlackHoleModel>? BlackHoleObjects = _objects.GetBlackholeObjects();

            if (BlackHoleObjects is null) return BadRequest(new { message = "No se encontraron datos." });

            return Ok(new { Status = "Success", Data = BlackHoleObjects });
        }
        catch (DataNotFoundException err)
        {
            return StatusCode(500, new { Error = "hubo un error al encontrar datos.", err });
        }
    }

    [HttpGet("{tipo}")]
    public IActionResult GetBlackholeObject(string tipo)
    {
        try
        {
            List<BlackHoleModel>? BlackHoleObjects = _objects.GetBlackholeObjects(tipo);
            if (BlackHoleObjects is null) return NotFound(new { message = "No se encontraron datos." });

            return Ok(new { Status = "Success", Data = BlackHoleObjects });
        }
        catch (DataNotFoundException err)
        {
            return StatusCode(500, new { Error = "hubo un error al encontrar datos.", err });
        }
    }

}



