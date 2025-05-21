using MessierAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MessierAPI.Repositories;
using MessierAPI.Exceptions;

// http://localhost:5034/api/Messier/Data

namespace MessierAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessierController : ControllerBase
{
    private readonly IJsonDataRep _objects;
    public MessierController(IJsonDataRep objects) => this._objects = objects;

    //General Delivery data.
    [HttpGet("Data")]
    public IActionResult GetMessierObjects()
    {
        try
        {
            List<MessierModel>? MessierObjects = _objects.GetMessierObjects();

            if (MessierObjects is null) return BadRequest(new { message = "No se encontraron datos." });

            return Ok(new { Status = "Success", Data = MessierObjects });
        }
        catch (DataNotFoundException err)
        {
            return StatusCode(500, new { Error = "hubo un error al encontrar datos.", err });
        }
    }

    //This endpoint tracks with a type filter.
    [HttpGet("{tipo}")]
    public IActionResult GetMessierObject(string tipo)
    {
        try
        {
            List<MessierModel>? MessierObject = _objects.GetMessierObjects(tipo);

            if (MessierObject is null) return BadRequest(new { message = "No se encontraron datos." });

            return Ok(new { Status = "Success", MessierObject });
        }
        catch (DataNotFoundException err)
        {
            return StatusCode(500, new { Error = "hubo un error al encontrar datos.", err });
        }

    }

}





