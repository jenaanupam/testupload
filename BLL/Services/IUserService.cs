using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
   public  interface IUserService
    {
         bool register(UserEntity usr);
    }
}
