using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;
using WMSMVC.Domain.Model;

namespace WMSMVC.Application.ViewModels.Client
{
    public class ClientAddresDetailVm : IMapFrom<ClientAdress>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int NumberOfHome { get; set; }
        public int? NumberOfFlat { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int ClientId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ClientAdress, ClientAddresDetailVm>()
                .ForMember(c => c.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(c => c.Street, opt => opt.MapFrom(s => s.Street))
                .ForMember(c => c.NumberOfHome, opt => opt.MapFrom(s => s.NumberOfHome))
                .ForMember(c => c.NumberOfFlat, opt => opt.MapFrom(s => s.NumberOfFlat))
                .ForMember(c => c.ZipCode, opt => opt.MapFrom(s => s.ZipCode))
                .ForMember(c => c.City, opt => opt.MapFrom(s => s.City))
                .ForMember(c => c.ClientId, opt => opt.MapFrom(s => s.ClientId));
        }
        public class NewClientValidation : AbstractValidator<ClientAddresDetailVm>
        {
            public NewClientValidation()
            {
                RuleFor(x => x.Street).MaximumLength(255);
                RuleFor(x => x.Street).NotNull();
                RuleFor(x => x.NumberOfHome).NotNull();
                RuleFor(x => x.ClientId).NotNull();
                RuleFor(x => x.City).NotNull();
                RuleFor(x => x.ZipCode).NotNull();

            }
        }
    }

}
