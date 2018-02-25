using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntity; 
namespace DataAccess.Gateway
{
    public interface IUserGateway
    {
       bool SaveDetails(UserEntity usr);
    }
}
