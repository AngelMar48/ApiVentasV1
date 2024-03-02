using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IPersonaService
{
    IEnumerable<PersonaDto> GetAllPersonas(bool trackChanges);

    PersonaDto GetPersona(Guid personaId, bool trackChanges);

    PersonaDto GetPersonaByIdentificacion(string identificacion, bool trackChanges);

    PersonaDto CreatePersona(NuevaPersona persona);

    void DeletePersonaFacturas(string identificacion, bool trackChanges);
}