using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;


namespace WMSMVC.Application.ViewModels.Client
{
    public class ClientVM : IMapFrom<WMSMVC.Web.Models.Client>
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NIP { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WMSMVC.Web.Models.Client, ClientVM>().ReverseMap()
                .ForMember(c => c.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(c => c.Company, opt => opt.MapFrom(s => s.Company))
                .ForMember(c => c.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(c => c.Surname, opt => opt.MapFrom(s => s.Surname))
                .ForMember(c => c.NIP, opt => opt.MapFrom(s => s.NIP));
        }
        public class ClientValidation : AbstractValidator<ClientVM>
        {
            public ClientValidation()
            {
                RuleFor(x => x.Company).NotNull();
                RuleFor(x => x.Name).NotNull();
                RuleFor(x => x.Surname).NotNull();
                RuleFor(x => x.NIP).Length(11);
                RuleFor(x => x.NIP).NotNull();
            }
        }
    }
}
