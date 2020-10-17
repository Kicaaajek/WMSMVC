using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;
using WMSMVC.Domain.Model;

namespace WMSMVC.Application.ViewModels.Worker
{
    public class WorkerContactDetailVM : IMapFrom<WorkersData>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WorkersData, WorkerContactDetailVM>().ReverseMap();
        }
    }
}
