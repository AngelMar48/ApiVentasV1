using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Data.SqlTypes;

namespace Service;

internal sealed class PersonaService : IPersonaService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public PersonaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
        _mapper = mapper;
    }

    public PersonaDto CreatePersona(NuevaPersona persona)
    {
        try
        {
            var personaIden = _repository.Persona.GetPersona(persona.Identificacion, false);
            if (personaIden != null)
                throw new PersonaNotFoundException();

            var personaEntity = _mapper.Map<Persona>(persona);
            _repository.Persona.CreatePersona(personaEntity);
            _repository.Save();

            var personaToReturn = _mapper.Map<PersonaDto>(personaEntity);

            return personaToReturn;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong duplicate identification {nameof(CreatePersona)} service method {ex}");
            throw;
        }
    }

    public void DeletePersonaByIdentificacion(string identificacion, bool trackChanges)
    {
        var persona = _repository.Persona.GetPersona(identificacion, trackChanges);
        if (persona is null)
            throw new PersonaNotFoundException();

        _repository.Persona.DeletePersona(persona);
        _repository.Save();
    }

    public IEnumerable<PersonaDto> GetAllPersonas(bool trackChanges)
    {
        try
        {
            var personas = _repository.Persona.GetAllPersonas(trackChanges);

            var personasDto = _mapper.Map<IEnumerable<PersonaDto>>(personas);

            return personasDto.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllPersonas)} service method {ex}");
            throw;
        }
    }


    public PersonaDto GetPersona(Guid id, bool trackChanges)
    {
        var persona = _repository.Persona.GetPersona(id, trackChanges);
        if (persona is null)
            throw new PersonaNotFoundException();

        var personaDto = _mapper.Map<PersonaDto>(persona);
        return personaDto;
    }


    public void DeletePersonaFacturas(string identificacion, bool trackChanges)
    {
        var persona = _repository.Persona.GetPersona(identificacion, trackChanges);
        if (persona is null)
            throw new PersonaNotFoundException();
        var facturas = _repository.Factura.GetFacturaByIdPersona(persona.Id, trackChanges);
        _repository.Factura.DeleteToListFacturas(facturas.ToList());
        _repository.Persona.DeletePersona(persona);
        _repository.Save();
    }

    public PersonaDto GetPersonaByIdentificacion(string identificacion, bool trackChanges)
    {
        var persona = _repository.Persona.GetPersona(identificacion, trackChanges);
        if (persona is null)
            throw new PersonaNotFoundException();

        var personaDto = _mapper.Map<PersonaDto>(persona);
        return personaDto;
    }


}
