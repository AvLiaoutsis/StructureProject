using Microsoft.AspNet.Identity;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace StructureProject.Helpers
{
    public static class IdentityExtensions
    {

        //public static string GetName(this IPrincipal user)
        //{
        //    if (user.Identity.IsAuthenticated)
        //    {
        //        ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
        //        foreach (var claim in claimsIdentity.Claims)
        //        {
        //            if (claim.Type == "Name")
        //                return claim.Value;
        //        }
        //        return "";
        //    }
        //    else
        //        return "";
        //}

        public static string GetName(this IPrincipal user) {

             var context = new ApplicationDbContext();

            if (user.Identity.IsAuthenticated)
            {
                var identityId = user.Identity.GetUserId();

                var person = context.Persons.SingleOrDefault(s => s.IdentityUserId == identityId);

                if(person is null)
                {
                    return "";
                }
                return person.Name;
            }
            else
            {
                return "";
            }
        }
    }
}