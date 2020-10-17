using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;
using WMSMVC.Domain.Model;

namespace WMSMVC.Application.ViewModels.Client
{
    public class ClientContactDetailVM : IMapFrom<ClientData>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int ClientId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ClientData, ClientContactDetailVM>().ReverseMap();
        }
        public class NewClientValidation : AbstractValidator<ClientContactDetailVM>
        {
            public NewClientValidation()
            {
                RuleFor(x => x.Email).EmailAddress();
                RuleFor(x => x.PhoneNumber).Length(9);
                RuleFor(x => x.PhoneNumber).NotNull();
                //RuleFor(x => x.ClientId).NotNull();

            }
        }
    }
}
