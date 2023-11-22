using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    //Meu Contrato
    void Create (T entity);
    void Update (T entity);
    void Delete (T entity);
    Task<T> GetById(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
                                                