
using Microsoft.AspNet.Identity;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StructureProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Person

        public AdminController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PersonList()
        {
            var identityId = User.Identity.GetUserId();

            var person = context.Persons.SingleOrDefault(s => s.IdentityUserId == identityId);

            var users = context.Persons
                .Where(s => s.IdentityUserId != person.IdentityUserId);

            return View(users);
        }

        public ActionResult Delete(int id)
        {
            var person = context.Persons.Single(s => s.Id == id);
            var user = context.Users.Single(s => s.Id == person.IdentityUserId);
            var contact = context.ContactInfos.Single(s => s.Person.Id == person.Id);
            var pets = context.Pets.Where(s => s.Owner.Id == person.Id);
            var hostinfo = context.HostInfos.Single(s => s.Person.Id == person.Id);
            var hostNotifications = context.HostNotifications.Where(s => s.Host.Id == id);
            var userNotifications = context.UserNotifications.Where(s => s.Host.Id == id || s.UserId == id);


            context.Persons.Remove(person);
            context.Users.Remove(user);
            context.ContactInfos.Remove(contact);
            context.Pets.RemoveRange(pets);
            context.HostInfos.Remove(hostinfo);
            context.HostNotifications.RemoveRange(hostNotifications);
            context.UserNotifications.RemoveRange(userNotifications);
            


            context.SaveChanges();
            return RedirectToAction("PersonList");
        }

        public ActionResult DeleteMail(int id)
        {
            var mail = context.Mails.Single(s => s.Id == id);

            context.Mails.Remove(mail);


            context.SaveChanges();
            return RedirectToAction("ViewMail");
        }

        public ActionResult ViewMail()
        {
            var mails = context.Mails.ToList();

            return View(mails);
        }
    }
}