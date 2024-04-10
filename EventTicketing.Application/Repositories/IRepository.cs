namespace EventTicketing.Application.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T?>> GetAllAsync();
    Task<IEnumerable<T?>> GetAllWithDetailsAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> GetByIdWithDetailsAsync(int id);
    Task AddAsync(T? entity);
    void Update(T? entity);
    Task DeleteAsync(int id);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}