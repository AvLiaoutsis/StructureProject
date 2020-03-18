using AutoMapper;
using StructureProject.DTO;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StructureProject.Controllers.API
{
    public class KindsController : ApiController
    {
        ApplicationDbContext context;

        public KindsController()
        {
            context = new ApplicationDbContext();

        }
        //GET /api/Kinds
        public IEnumerable<KindDTO> GetKinds()
        {

            return context.Kinds
                .ToList()
                .Select(Mapper.Map<Kind, KindDTO>);

        }

        //GET /api/Kinds/id
        public IEnumerable<KindDTO> GetKinds(byte id)
        {

            return context.Kinds
                .Where(k=>k.Id == id)
                .ToList()
                .Select(Mapper.Map<Kind, KindDTO>);

        }
    }
}