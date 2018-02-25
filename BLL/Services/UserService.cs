using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntity;
using DataAccess.Gateway;
namespace BLL.Services
{
   public class UserService : IUserService
    {
        public readonly IUserGateway _IUserGateway;
        public UserService(IUserGateway IUserGateway)
        {
            _IUserGateway = IUserGateway;
        }
        public bool register(UserEntity usr)
        {
            return _IUserGateway.SaveDetails(usr);
        }

         
    }
}
