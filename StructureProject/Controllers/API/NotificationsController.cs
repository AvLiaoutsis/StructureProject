using AutoMapper;
using Microsoft.AspNet.Identity;
using StructureProject.DTO;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StructureProject.Controllers.API
{
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
        }

        public IEnumerable<UserNotification> GetNotifications()
        {
            var userId = User.Identity.GetUserId();


            return context.UserNotifications
                    .Where(s => s.User.IdentityUserId == userId)

                    .ToList();
        }
    }
}