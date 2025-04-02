using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class UserController : Controller
    {
       
        private static List<User> users = new List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var existingUser = users.FirstOrDefault(x => x.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Address = user.Address;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(User user)
        {
            var existingUser = users.FirstOrDefault(x => x.Id == user.Id);
            if (existingUser != null)
            {
                users.Remove(existingUser);
            }
            return RedirectToAction("Index");
        }
    }
}