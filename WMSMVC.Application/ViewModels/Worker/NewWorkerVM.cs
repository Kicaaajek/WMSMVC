using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;

namespace WMSMVC.Application.ViewModels.Worker
{
    public class NewWorkerVM : IMapFrom<WMSMVC.Domain.Model.Worker>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WMSMVC.Domain.Model.Worker, NewWorkerVM>().ReverseMap();
        }
    }
}
