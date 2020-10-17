using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Domain.Intefaces;
using WMSMVC.Domain.Model;

namespace WMSMVC.Infrastructure.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly Context _context;
        public WorkerRepository(Context context)
        {
            _context = context;
        }
        public int AddAddress(WorkersAdress address)
        {
            _context.WorkersAdresses.Add(address);
            _context.SaveChanges();
            return address.Id;
        }

        public int AddContact(WorkersData contact)
        {
            _context.WorkersDatas.Add(contact);
            _context.SaveChanges();
            return contact.Id;
        }

        public int AddNew(Worker worker)
        {
            _context.Workers.Add(worker);
            _context.SaveChanges();
            return worker.Id;
        }

        public void AddNewWorkDone(WorkDone workDone)
        {
            _context.WorkDones.Add(workDone);
            _context.SaveChanges();
        }

        public IQueryable<WorkDone> GetWorkDones(int id)
        {
            var workDone = _context.WorkDones.Where(w => w.WorkerId == id);
            return workDone;
        }

        public Worker GetWorker(int id)
        {
            var worker = _context.Workers.FirstOrDefault(w => w.Id == id);
            return worker;
        }

        public IQueryable<Worker> GetWorkers()
        {
            var workers = _context.Workers;
            return workers;
        }

        public WorkersAdress GetWorkersAdresses(int id)
        {
            var addresses = _context.WorkersAdresses.FirstOrDefault(w => w.WorkerId == id);
            return addresses;
        }

        public WorkersData GetWorkersData(int id)
        {
            var contact = _context.WorkersDatas.FirstOrDefault(w => w.WorkerId == id);
            return contact;
        }

        public IQueryable<WorkDone> GetWorkerWithoutStandard(DateTime date)
        {
            var standard = _context.WorkDones.Where(w =>w.DateTime==date && w.Standard == false);
            return standard;
        }

        public void Remove(int id)
        {
            var worker=_context.Workers.Find(id);
            if(worker!=null)
            {
                _context.Workers.Remove(worker);
                _context.SaveChanges();
            }
        }

        public void RemoveAddress(int id)
        {
            var address = _context.WorkersAdresses.Find(id);
            if(address!=null)
            {
                _context.WorkersAdresses.Remove(address);
                _context.SaveChanges();
            }
        }

        public void RemoveContact(int id)
        {
            var contact = _context.WorkersDatas.Find(id);
            if(contact!=null)
            {
                _context.WorkersDatas.Remove(contact);
                _context.SaveChanges();
            }
        }

        public void Update(Worker worker)
        {
            _context.Attach(worker);
            _context.Entry(worker).Property("Name").IsModified = true;
            _context.Entry(worker).Property("Surname").IsModified = true;
            _context.Entry(worker).Property("DateOfBirth").IsModified = true;
            _context.SaveChanges();
        }

        public void UpdateAddress(WorkersAdress address)
        {
            _context.Attach(address);
            _context.Entry(address).Property("Street").IsModified = true;
            _context.Entry(address).Property("NumberOfHome").IsModified = true;
            _context.Entry(address).Property("NumberOfFlat").IsModified = true;
            _context.Entry(address).Property("ZipCode").IsModified = true;
            _context.Entry(address).Property("City").IsModified = true;
            _context.SaveChanges();
        }

        public void UpdateContact(WorkersData contact)
        {
            _context.Attach(contact);
            _context.Entry(contact).Property("Email").IsModified = true;
            _context.Entry(contact).Property("PhoneNumber").IsModified = true;           
            _context.SaveChanges();
        }

    }
}
