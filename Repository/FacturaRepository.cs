using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace Repository;

internal sealed class FacturaRepository : RepositoryBase<Factura>, IFacturaRepository
{

  

    public FacturaRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
        

    }

    public void CreateFactura(Factura factura) => Create(factura);
   

    
    public IEnumerable<Factura> GetAllFacturas(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.Id)
        .ToList();


    public IEnumerable<Factura> GetFacturaByIdPersona(Guid id, bool trackChanges) =>
        FindByCondition(x => x.PersonaId.Equals(id), trackChanges)
        .OrderBy(c => c.Id)
        .ToList();

    public void DeleteToListFacturas(List<Factura> entities) => DeleteToList(entities);

    
}
