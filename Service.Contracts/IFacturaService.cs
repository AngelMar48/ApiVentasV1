using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IFacturaService
{
    IEnumerable<FacturaDto> GetAllFacturas(bool trackChanges);


    PersonaFacturasDto GetFacturaByIdPersona(Guid Id, bool trackChanges);

    FacturaDto CreateFactura(NuevaFactura item);

}