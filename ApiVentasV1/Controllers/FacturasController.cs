using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace ApiVentasV1.Controllers;

[Route("api/Ventas")]
[ApiController]
public class FacturasController : ControllerBase
{
	private readonly IServiceManager _service;

	public FacturasController(IServiceManager service) => _service = service;


	/// <summary>
	/// Obtener todas las facturas
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	public IActionResult GetFacturas()
	{
		try
		{
			var facturas = _service.FacturaService.GetAllFacturas(trackChanges: false);

			return Ok(facturas);
		}
		catch
		{
			return StatusCode(500, "Internal server error");
		}
	}

    /// <summary>
    /// Obtener Facturas por el Id de la Persona
    /// </summary>
    /// <param name="personaId"></param>
    /// <returns></returns>
    [HttpGet("{personaId:guid}", Name = "GetFacturaPorIdPersona")]
    public IActionResult GetFacturaPorIdPersona(Guid personaId)
    {
        var result = _service.FacturaService.GetFacturaByIdPersona(personaId, trackChanges: false);
        return Ok(result);
    }

    /// <summary>
    /// Crear nueva Factura
    /// </summary>
    /// <param name="persona"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult CreateFactura([FromBody] NuevaFactura item)
    {
        if (item is null)
            return BadRequest("Persona object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdFactura = _service.FacturaService.CreateFactura(item);
        //_service.FacturaService.CreateFactura(item);

        return CreatedAtRoute("PersonaById", new { id = createdFactura.Id }, createdFactura);
    }
}
