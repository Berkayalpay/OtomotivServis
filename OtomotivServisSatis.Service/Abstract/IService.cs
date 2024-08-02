using OtomotivServisSatis.Data.Abstract;
using OtomotivServisSatis.Entities;

namespace OtomotivServisSatis.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class , IEntity , new()
    {



    }
}
