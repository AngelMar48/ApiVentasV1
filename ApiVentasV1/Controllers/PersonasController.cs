using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.ComponentModel.Design;

namespace ApiVentasV1.Controllers;

[Route("api/Directorio")]
[ApiController]
public class PersonasController : ControllerBase
{
	private readonly IServiceManager _service;

	public PersonasController(IServiceManager service) => _service = service;

	[HttpGet]
	public IActionResult GetPersonas()
	{
		try
		{
			var personas = _service.PersonaService.GetAllPersonas(trackChanges: false);

			return Ok(personas);
		}
		catch
		{
			return StatusCode(500, "Internal server error");
		}
	}




    /// <summary>
    /// Obtener Persona Por Identificaión
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{identificacion}", Name = "identificacion")]
    public IActionResult GetPersonaByIdentificacion(string identificacion)
    {
        var persona = _service.PersonaService.GetPersonaByIdentificacion(identificacion, trackChanges: false);
        return Ok(persona);
    }

    /// <summary>
    /// Obtener Persona Por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}", Name = "PersonaById")]
    public IActionResult FindPersona(Guid id)
    {
        var persona = _service.PersonaService.GetPersona(id, trackChanges: false);
        return Ok(persona);
    }



    /// <summary>
    /// Crear nueva Persona
    /// </summary>
    /// <param name="persona"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult StorePersona([FromBody] NuevaPersona persona)
    {
        if (persona is null)
            return BadRequest("Persona object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdPersona = _service.PersonaService.CreatePersona(persona);

        return CreatedAtRoute("PersonaById", new { id = createdPersona.Id }, createdPersona);
    }



    /// <summary>
    /// Elimina una Persona y sus facturas asignadas
    /// </summary>
    /// <param name="identificacion"></param>
    /// <returns></returns>
    [HttpDelete("{identificacion}")]
    public IActionResult DeletePersonaByIdentificacion(string identificacion)
    {
        _service.PersonaService.DeletePersonaFacturas(identificacion, trackChanges: false);

        return NoContent();
    }
}
