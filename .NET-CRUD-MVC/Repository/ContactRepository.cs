using System;
using System.Collections.Generic;
using System.Linq;
using ASPNET_CRUD_MVC.Data;
using ASPNET_CRUD_MVC.Models;

namespace ASPNET_CRUD_MVC.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ContactRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ContactModel Add(ContactModel contact)
        {
            _databaseContext.Contact.Add(contact);
            _databaseContext.SaveChanges();
            return contact;
        }

        public bool Delete(int id)
        {
            ContactModel contactDb = GetById(id);
            if (contactDb == null) throw new System.Exception("error during contact delete");

            _databaseContext.Contact.Remove(contactDb);
            _databaseContext.SaveChanges();
            return true;
        }

        public List<ContactModel> GetAll()
        {
            return _databaseContext.Contact.ToList();
        }

        public ContactModel GetById(int id)
        {
            return _databaseContext.Contact.FirstOrDefault(a => a.Id == id);
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactDb = GetById(contact.Id);
            if (contactDb == null) throw new System.Exception("error during contact update");


            contactDb.Name = contact.Name;
            contactDb.Email = contact.Email;
            contactDb.PhoneNumber = contact.PhoneNumber;

            _databaseContext.Contact.Update(contactDb);
            _databaseContext.SaveChanges();
            return contactDb;
        }
    }
}

