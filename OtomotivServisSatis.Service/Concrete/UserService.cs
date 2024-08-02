using OtomotivServisSatis.Data;
using OtomotivServisSatis.Data.Concrete;
using OtomotivServisSatis.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomotivServisSatis.Service.Concrete
{
    public class UserService : UserRepository , IUserService
    {
        public UserService(DatabaseContext context) : base(context)
        {

        }


    }
}
