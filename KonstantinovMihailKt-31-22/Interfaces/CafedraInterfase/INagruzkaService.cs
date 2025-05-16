using KonstantinovMihailKt_31_22.Database;
using KonstantinovMihailKt_31_22.Filters.CafedraFilters;
using KonstantinovMihailKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace KonstantinovMihailKt_31_22.Interfaces.CafedraInterfase
{
    public interface INagruzkaService
    {
        public Task<Nagruzka[]> GetNagruzkasByFiltersAsync(NagruzkaFilter filter, CancellationToken cancellationToken);
    }

    public class NagruzkaService : INagruzkaService
    {
        public readonly NagruzkaDbContext _dbContext;

        public NagruzkaService(NagruzkaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Nagruzka[]> GetNagruzkasByFiltersAsync(NagruzkaFilter filter, CancellationToken cancellationToken = default)
        {

            var query = _dbContext.Set<Nagruzka>()
            .Include(n => n.Prepod)
            .Include(n => n.Disciplines) 
            .AsQueryable();

            if (filter.prepodId.HasValue)
                query = query.Where(n => n.PrepodId == filter.prepodId.Value);

            if (filter.disciplinId.HasValue)
                query = query.Where(n => n.DisciplineId == filter.disciplinId.Value); 

            return await query.ToArrayAsync(cancellationToken);

        }
    }
}
