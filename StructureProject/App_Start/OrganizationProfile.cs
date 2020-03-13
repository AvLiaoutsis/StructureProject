using AutoMapper;
using StructureProject.DTO;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.App_Start
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();

            CreateMap<Pet, PetDTO>();
            CreateMap<PetDTO, Pet>();

            CreateMap<ContactInfo, ContantInfoDTO>();
            CreateMap<ContantInfoDTO, ContactInfo>();

            CreateMap<Mail, MailDTO>();
            CreateMap<MailDTO, Mail>();

            CreateMap<HostInfo, HostInfoDTO>();
            CreateMap<HostInfoDTO, HostInfo>();

            CreateMap<Reservation, ReservationDTO>();
            CreateMap<ReservationDTO, Reservation>();
        }
    }
}