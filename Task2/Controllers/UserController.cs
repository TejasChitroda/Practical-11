using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class UserController : Controller
    {

        private static List<User> users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Name = "John Doe", Email = "john@doe.com", DateOfBirth = new DateTime(1990, 5, 15), Address = "123   Main  St, New York, NY" },
            new User { Id = Guid.NewGuid(), Name = "Jane Doe", Email = "jane@doe.com", DateOfBirth = new DateTime(1992, 8, 22), Address = "456   Elm   St, Los Angeles, CA" },
            new User { Id = Guid.NewGuid(), Name = "Joe Bloggs", Email = "joe@bloggs.com", DateOfBirth = new DateTime(1985, 12, 10), Address =   "789  Oak St, Chicago, IL" }
        };



        // GET: User
        // This method is used to display the list of users
        public ActionResult Index()
        {
            return View(users);
        }

        // GET: User/Create
        // This method is used to display the form to create a new user
        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }

        // POST: User/Create
        // This method is used to handle the form submission and create a new user
        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Id = Guid.NewGuid();
            users.Add(user);
            return RedirectToAction("Index");
        }

        // GET: User/Edit/{id}
        // This method is used to display the form to edit an existing user
        public ActionResult Edit(Guid id)
        {
            var user = users.FirstOrDefault(u => u.Id.Equals(id));
            return View("_Edit",user);
        }

        // POST: User/Edit
        // This method is used to handle the form submission and update an existing user
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id.Equals(user.Id));
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Address = user.Address;
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", user);
        }

        // GET: User/Delete/{id}
        // This method is used to display the confirmation dialog to delete a user
        public PartialViewResult Delete(Guid id)
        {
            var user = users.FirstOrDefault(u => u.Id.Equals(id));
            return PartialView("_Delete", user);
        }


        // POST
        // This method is used to handle the form submission and delete a user
        [HttpPost]
        public ActionResult Delete(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id.Equals(user.Id));
            if (existingUser != null)
            {
                users.Remove(existingUser);
                return RedirectToAction("Index");
            }
            return PartialView("_Delete", user);
        }

        // GET: User/Details/{id}
        // This method is used to display the details of a user
        public ActionResult Details(Guid id)
        {
            var user = users.FirstOrDefault(u => u.Id.Equals(id));
            return View("_Details", user);
        }

       


    }
}