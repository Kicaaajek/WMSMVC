using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Domain.Model;

namespace WMSMVC.Domain.Intefaces
{
    public interface IWorkerRepository
    {
        int AddNew(Worker worker);
        void Update(Worker worker);
        void Remove(int id);
        int AddAddress(WorkersAdress address);
        int AddContact(WorkersData contact);
        void UpdateAddress(WorkersAdress address);
        void UpdateContact(WorkersData contact);
        void RemoveContact (int id);
        void RemoveAddress (int id);
        void AddNewWorkDone(WorkDone workDone);
        WorkersAdress GetWorkersAdresses(int id);
        IQueryable<Worker> GetWorkers();
        Worker GetWorker(int id);
        WorkersData GetWorkersData(int id);
        IQueryable<WorkDone> GetWorkDones(int id);
        IQueryable<WorkDone> GetWorkerWithoutStandard(DateTime date);
    }
}
