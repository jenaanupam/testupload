using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntity;

namespace DataAccess.Gateway
{
    public class UserGateway : IUserGateway
    {
      
        public bool SaveDetails(UserEntity usr)
        {
            return true;
        }
    }
}
