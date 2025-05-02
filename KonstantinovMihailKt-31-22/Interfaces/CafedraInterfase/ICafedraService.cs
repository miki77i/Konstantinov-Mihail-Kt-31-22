using KonstantinovMihailKt_31_22.Database;
using KonstantinovMihailKt_31_22.Filters.CafedraFilters;
using KonstantinovMihailKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace KonstantinovMihailKt_31_22.Interfaces.CafedraInterfase
{
    public interface ICafedraService
    {
        public Task<Cafedra[]> GetCafedrasByFilterAsync(CafedraFilter filter, CancellationToken cancellationToken);
    }

    public class CafedraService : ICafedraService
    {
        public readonly CafedraDbContext _dbContext;

        public CafedraService(CafedraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cafedra[]> GetCafedrasByFilterAsync(CafedraFilter filter, CancellationToken cancellationToken = default)
        {

            var query = _dbContext.Set<Cafedra>()
            .Include(c => c.Admin)
            .AsQueryable();

            if (filter.Date_ != null)
                query = query.Where(c => c.dataosnovania == filter.Date_);

            if (filter.totalPrepods_.HasValue)
                query = query.Where(c => c.totalPrerods == filter.totalPrepods_.Value); 

            var result = await query.ToArrayAsync(cancellationToken);
            return result;

        }
    }
}
