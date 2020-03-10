using AutoMapper;
using Microsoft.AspNet.Identity;
using StructureProject.DTO;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;


namespace StructureProject.Controllers.API
{
    public class HostsController : ApiController
    {
        private ApplicationDbContext context;

        public HostsController()
        {
            context = new ApplicationDbContext();
        }

        public IEnumerable<HostInfoDTO> GetHostInfos()
        {
            var identityId = User.Identity.GetUserId();

            return context.HostInfos
                .Include(s => s.Person)
                .Where(s => !(s.Person.IdentityUserId == identityId))
                .ToList()
                .Select(Mapper.Map<HostInfo, HostInfoDTO>);

        }

    }
}