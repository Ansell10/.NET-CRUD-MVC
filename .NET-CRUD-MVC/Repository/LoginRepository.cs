using System;
using System.Collections.Generic;
using System.Linq;
using ASPNET_CRUD_MVC.Data;
using ASPNET_CRUD_MVC.Models;

namespace ASPNET_CRUD_MVC.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DatabaseContext _databaseContext;
        public LoginRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public UserModel Login(LoginModel loginModel)
        {
            UserModel userModel =
             _databaseContext.User.Where(a => a.UserName == loginModel.UserName && a.Password == loginModel.Password).FirstOrDefault();

            return userModel;
        }
    }
}

