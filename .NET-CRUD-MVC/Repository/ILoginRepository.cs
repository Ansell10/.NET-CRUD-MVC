using System;
using System.Collections.Generic;
using ASPNET_CRUD_MVC.Models;

namespace ASPNET_CRUD_MVC.Repository
{
    public interface ILoginRepository
    {
        UserModel Login(LoginModel loginModel);
    }
}

