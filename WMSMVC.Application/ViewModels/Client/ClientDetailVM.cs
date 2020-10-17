using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;
using WMSMVC.Web.Models;

namespace WMSMVC.Application.ViewModels.Client
{
    public class ClientDetailVM : IMapFrom<WMSMVC.Web.Models.Client>
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string FullName { get; set; }
        public string NIP { get; set; }
        public List<ClientAddresDetailVm> Addreses { get; set; }
        public int AdressesCount { get; set; }
        public List<ClientContactDetailVM> ContactDetails { get; set; }
        public int ContactsCount { get; set; }
        public int ClientId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WMSMVC.Web.Models.Client, ClientDetailVM>()
                .ForMember(c => c.FullName, opt => opt.MapFrom(d => d.Name + " " + d.Surname))
                .ForMember(c => c.ClientId, opt => opt.MapFrom(d => d.Id))
                .ReverseMap();
        }
        public class NewClientValidation : AbstractValidator<ClientDetailVM>
        {
            public NewClientValidation()
            {
                RuleFor(x => x.Company).MaximumLength(255);
                RuleFor(x => x.NIP).Length(10);

            }
        }
    }
    
}

