using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("StructureProject", throwIfV1Schema: false)
        {

        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<HostInfo> HostInfos { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<PriceKind> PriceKinds { get; set; }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}