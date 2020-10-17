using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;
using WMSMVC.Web.Models;

namespace WMSMVC.Application.ViewModels.Items
{
    public class ItemVM : IMapFrom<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WMSMVC.Web.Models.Item, ItemVM>().ReverseMap();
        }
        public class NewItemValidation : AbstractValidator<ItemVM>
        {
            public NewItemValidation()
            {
                RuleFor(x => x.Name).NotNull();
                RuleFor(x => x.Quantity).NotNull();
                RuleFor(x => x.Price).NotNull();
                RuleFor(x => x.CategoryId).NotNull();

            }
        }
    }
}
