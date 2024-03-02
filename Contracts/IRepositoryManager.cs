namespace Contracts;

public interface IRepositoryManager
{
    IFacturaRepository Factura { get; }
    IPersonaRepository Persona { get; }

	void Save();
}
