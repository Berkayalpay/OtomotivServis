using OtomotivServisSatis.Data;
using OtomotivServisSatis.Data.Concrete;
using OtomotivServisSatis.Service.Abstract;

namespace OtomotivServisSatis.Service.Concrete
{
    public class CarService : CarRepository,ICarService
    {
        public CarService(DatabaseContext context) : base(context)
        {

        }
    }
}
