using AutoMapper;
using Microsoft.AspNet.Identity;
using StructureProject.DTO;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StructureProject.Controllers.API
{
    public class HostNotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public HostNotificationsController()
        {
            context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.HostNotifications 
                .Where(un => un.Host.IdentityUserId == userId && !un.IsRead)
                .ToList();

            notifications.ForEach(n => n.Read());

            context.SaveChanges();

            return Ok();
        }

        public IEnumerable<UserNotificationDTO> GetNotifications()
        {
            var userId = User.Identity.GetUserId();

            var hostnotifications = context.HostNotifications
               .Where(un => un.Host.IdentityUserId == userId && !un.IsRead)
               .Include(s => s.User)
               .Include(s => s.Pet)
               .Include(n => n.Notification)
               .ToList()
               .Select(Mapper.Map<HostNotification, UserNotificationDTO>);

            return hostnotifications;
        }
    }
}
