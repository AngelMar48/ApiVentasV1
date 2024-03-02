using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IPersonaService> _personaService;
    private readonly Lazy<IFacturaService> _facturaService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _personaService = new Lazy<IPersonaService>(() =>
           new PersonaService(repositoryManager, logger, mapper));
        _facturaService = new Lazy<IFacturaService>(() =>
            new FacturaService(repositoryManager, logger, mapper));
    }

    public IPersonaService PersonaService => _personaService.Value;

    public IFacturaService FacturaService => _facturaService.Value;
}