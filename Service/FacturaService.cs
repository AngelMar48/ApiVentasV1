using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class FacturaService : IFacturaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public FacturaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<FacturaDto> GetAllFacturas(bool trackChanges)
    {
        try
        {
            var facturas = _repository.Factura.GetAllFacturas(trackChanges);
            if (facturas == null)
                throw new CollectionException();

            var facturasDto = _mapper.Map<IEnumerable<FacturaDto>>(facturas);

            return facturasDto.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllFacturas)} service method {ex}");
            throw;
        }
    }


    public PersonaFacturasDto GetFacturaByIdPersona(Guid id, bool trackChanges)
    {
        try
        {
            var name = _repository.Persona.GetPersona(id, trackChanges);
            if (name is null)
                throw new IdParametersBadRequestException();

            var facturas = _repository.Factura.GetFacturaByIdPersona(id, trackChanges);


            var facturasList = _mapper.Map<IEnumerable<FacturaDto>>(facturas);
            var nombre = _mapper.Map<PersonaFullName>(name);

            PersonaFacturasDto personaFacturasDto = new PersonaFacturasDto
            {
                NombreCompleto = nombre.FullName,
                Facturas = facturasList
            };
            return personaFacturasDto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllFacturas)} service method {ex}");
            throw;
        }
    }

    public FacturaDto CreateFactura(NuevaFactura item)
    {
        
        var facturaEntity = _mapper.Map<Factura>(item);
        facturaEntity.Id = Guid.NewGuid();
        _repository.Factura.CreateFactura(facturaEntity);

        _repository.Save();

        var FacturaToReturn = _mapper.Map<FacturaDto>(facturaEntity);

        return FacturaToReturn;
    }

}
