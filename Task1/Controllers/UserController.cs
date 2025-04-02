using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class UserController : Controller
    {
        // This is a simple in-memory data store
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john@doe.com" , Role = "Admin" },
            new User { Id = 2, Name = "Jane Doe", Email = "jane@doe.com" , Role = "Developer"},
            new User { Id = 3, Name = "Joe Bloggs", Email = "joe@bloggs.com" , Role = "Manager" }
        };  
        // GET: User
        public ActionResult Index()
        {
            return View(users);
        }

        // GET: User/Create
        // This method is used to display the form to create a new user
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // This method is used to handle the form submission and create a new user
        [HttpPost]
        public ActionResult Create(User user)
        {
            users.Add(user);
            return RedirectToAction("Index");
        }

        // GET: User/Edit/{id}
        // This method is used to display the form to edit an existing user
        public ActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // POST: 
        // This method is used to handle the form submission and update an existing user
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Role = user.Role;
                return RedirectToAction("Index");
            }

            return Content("User not found");

        }

        // GET: User/Details/{id}
        // This method is used to display the details of a user
        public ActionResult Details(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // GET: User/Delete/{id}
        // This method is used to display the confirmation page for deleting a user
        public ActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(d => d.Id == id);
            
            return View(user);
        }

        // POST: 
        // This method is used to handle the form submission and delete a user
        [HttpPost]
        public ActionResult Delete(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                users.Remove(existingUser);
                return RedirectToAction("Index");
            }
            return Content("User not found");
        }
    }
}