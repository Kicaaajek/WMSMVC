using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;
using WMSMVC.Application.ViewModels.Items;

namespace WMSMVC.Application.ViewModels.Category
{
    public class CategoryVM : IMapFrom<WMSMVC.Web.Models.Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemVM> Items { get; set; }
        public int ItemCount { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WMSMVC.Web.Models.Category, CategoryVM>().ReverseMap();
        }
        public class NewCategoryValidation : AbstractValidator<CategoryVM>
        {
            public NewCategoryValidation()
            {
                RuleFor(x => x.Name).NotNull();
            }
        }
    }
}
