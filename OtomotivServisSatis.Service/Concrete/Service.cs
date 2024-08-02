using OtomotivServisSatis.Data;
using OtomotivServisSatis.Data.Concrete;
using OtomotivServisSatis.Entities;
using OtomotivServisSatis.Service.Abstract;

namespace OtomotivServisSatis.Service.Concrete
{
    public class Service<T> : Repository<T>,IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context) : base(context)
        {
        }

    }
}
