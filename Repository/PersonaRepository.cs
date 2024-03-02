using Contracts;
using Entities.Models;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository;

internal sealed class PersonaRepository : RepositoryBase<Persona>, IPersonaRepository
{
	public PersonaRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public void CreatePersona(Persona persona) => Create(persona);

    public void DeletePersona(Persona persona) => Delete(persona);


    public IEnumerable<Persona> GetAllPersonas(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.Nombre)
        .ToList();

    public IEnumerable<Persona> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.Id), trackChanges)
        .ToList();

    public Persona GetPersona(Guid personaId, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(personaId), trackChanges)
        .SingleOrDefault();

    public void DeleteToListPersona(List<Persona> entities) => DeleteToList(entities);

    public Persona GetPersona(string identificacion, bool trackChanges) =>
        FindByCondition(c => c.Identificacion.Equals(identificacion), trackChanges)
        .SingleOrDefault();
}
