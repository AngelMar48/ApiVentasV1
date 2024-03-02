using Entities.Models;

namespace Contracts;

public interface IPersonaRepository
{
    IEnumerable<Persona> GetAllPersonas(bool trackChanges);

    Persona GetPersona(Guid personaId, bool trackChanges);

    Persona GetPersona(string identificacion, bool trackChanges);
    void CreatePersona(Persona persona);
    void DeletePersona(Persona persona);
    void DeleteToListPersona(List<Persona> entities);
}
