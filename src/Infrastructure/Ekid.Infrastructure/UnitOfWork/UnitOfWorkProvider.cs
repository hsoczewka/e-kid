namespace Ekid.Infrastructure.UnitOfWork;

public class UnitOfWorkProvider
{
    private readonly IEnumerable<IUnitOfWork> _unitOfWorks;

    public UnitOfWorkProvider(IEnumerable<IUnitOfWork> unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public IUnitOfWork GetForType(Type type)
    {
        
    }
}