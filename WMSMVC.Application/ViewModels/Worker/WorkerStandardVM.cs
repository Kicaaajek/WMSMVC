using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;
using WMSMVC.Domain.Model;

namespace WMSMVC.Application.ViewModels.Worker
{
    public class WorkerStandardVM : IMapFrom<WMSMVC.Domain.Model.WorkDone>
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int QuantityOfWork { get; set; }
        public bool Standard { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WorkDone, WorkerStandardVM>().ReverseMap();
        }
    }
}
