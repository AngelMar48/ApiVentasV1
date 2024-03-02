using Entities.Models;

namespace Contracts;

public interface IFacturaRepository
{
    IEnumerable<Factura> GetAllFacturas(bool trackChanges);

    IEnumerable<Factura> GetFacturaByIdPersona(Guid id, bool trackChanges);

    void CreateFactura(Factura factura);

    void DeleteToListFacturas(List<Factura> facturas);
}
