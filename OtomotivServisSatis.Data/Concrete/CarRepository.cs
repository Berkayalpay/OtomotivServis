using Microsoft.EntityFrameworkCore;
using OtomotivServisSatis.Data.Abstract;
using OtomotivServisSatis.Entities;
using System.Linq.Expressions;

namespace OtomotivServisSatis.Data.Concrete
{
    public class CarRepository : Repository<Arac>, ICarRepository
    {
        public CarRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<Arac> GetCustomCar(int id)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Marka).FirstOrDefaultAsync(c=>c.Id == id);
        }

        public async Task<List<Arac>> GetCustomCarList()
        {
            return await _dbSet.AsNoTracking().Include(x=>x.Marka).ToListAsync();//AsNoTracking performans arttırdı.
        }

        public async Task<List<Arac>> GetCustomCarList(Expression<Func<Arac, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Marka).ToListAsync();
        }
    }
}
