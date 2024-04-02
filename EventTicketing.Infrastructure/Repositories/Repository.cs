using System.Linq.Expressions;
using EventTicketing.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventTicketingApi.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> GetByIdWithDetailsAsync(int id)
    {
        IQueryable<T> query = _dbSet;
        var entityType = _context.Model.FindEntityType(typeof(T));

        // Include all navigation properties
        foreach (var navigation in entityType.GetNavigations())
        {
            query = query.Include(navigation.Name);
        }

        var key = entityType.FindPrimaryKey().Properties[0];
        var parameter = Expression.Parameter(typeof(T), "e");
        var body = Expression.Equal(
            Expression.PropertyOrField(parameter, key.Name),
            Expression.Constant(id)
        );
        var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);

        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task AddAsync(T? entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T? entity)
    {
        _dbSet.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
