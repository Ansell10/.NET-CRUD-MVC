using System;
using System.Collections.Generic;
using ASPNET_CRUD_MVC.Models;

namespace ASPNET_CRUD_MVC.Repository
{
    public interface IUserRepository
    {
        UserModel Add(UserModel userModel);
        UserModel GetById(int Id);
        UserModel GetByUserName(String UserName);
        UserModel Update(UserModel userModel);
        bool Delete(int Id);

        List<UserModel> GetAll();
    }
}

