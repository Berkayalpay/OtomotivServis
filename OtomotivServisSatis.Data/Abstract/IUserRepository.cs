using OtomotivServisSatis.Entities;
using System.Linq.Expressions;

namespace OtomotivServisSatis.Data.Abstract
{
    public interface IUserRepository : IRepository<Kullanici>
    {
        Task<List<Kullanici>> GetCustomList();
        Task<List<Kullanici>> GetCustomList(Expression<Func<Kullanici, bool>> expression);


    }
}
