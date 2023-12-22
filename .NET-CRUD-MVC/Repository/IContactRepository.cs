using System;
using System.Collections.Generic;
using ASPNET_CRUD_MVC.Models;

namespace ASPNET_CRUD_MVC.Repository
{
    public interface IContactRepository
    {
        ContactModel Add(ContactModel contact);
        ContactModel GetById(int id);
        ContactModel Update(ContactModel contact);
        bool Delete(int id);

        List<ContactModel> GetAll();
    }
}

