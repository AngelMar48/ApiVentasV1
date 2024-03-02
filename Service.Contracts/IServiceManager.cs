namespace Service.Contracts;

public interface IServiceManager
{
    IPersonaService	 PersonaService { get; }
    IFacturaService FacturaService { get; }
}
