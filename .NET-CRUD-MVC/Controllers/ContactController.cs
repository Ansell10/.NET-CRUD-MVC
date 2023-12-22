using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_CRUD_MVC.Models;
using ASPNET_CRUD_MVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_CRUD_MVC.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;
        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<ContactModel> list = _repository.GetAll();
            return View(list);
        }

        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(contact);
                    TempData["SucessMessage"] = "Contact was stored successfully";
                    return RedirectToAction("Index");
                }


                return View(contact);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"We have a problem during process to create a contact. Details {ex.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult EditContact(int id)
        {
            ContactModel model = _repository.GetById(id);
            return View(model);
        }


        [HttpPost]
        public IActionResult EditContact(ContactModel contact)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(contact);
                    TempData["SucessMessage"] = "Contact was updated successfully";
                    return RedirectToAction("Index");
                }


                return View(contact);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"We have a problem during process to update a contact. Details {ex.Message}";
                return RedirectToAction("Index");
            }

        }



        public IActionResult ConfirmToDeleteContact(int id)
        {
            ContactModel model = _repository.GetById(id);
            return View(model);
        }

        public IActionResult DeleteContact(int id)
        {
            try
            {
                bool deleted = _repository.Delete(id);
                if (deleted)
                {
                    TempData["SucessMessage"] = "Contact was deleted successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "We have a problem during process to delete a contact";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"We have a problem during process to delete a contact. Details {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
