using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	

    private readonly Lazy<IPersonaRepository> _personaRepository;
    private readonly Lazy<IFacturaRepository> _facturaRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
		

        _personaRepository = new Lazy<IPersonaRepository>(() => new PersonaRepository(repositoryContext));
        _facturaRepository = new Lazy<IFacturaRepository>(() => new FacturaRepository(repositoryContext));
    }

    public IPersonaRepository Persona => _personaRepository.Value;
    public IFacturaRepository Factura => _facturaRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();
}
