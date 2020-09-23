using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Domain.Intefaces;
using WMSMVC.Domain.Model;
using WMSMVC.Web.Models;

namespace WMSMVC.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly Context _context;
        public ClientRepository(Context context)
        {
            _context = context;
        }
        public void AddNew(string name, string surname, DateTime birth, string email,string number)
        {
            _context.Clients.Add(new Client(name, surname));
            _context.SaveChanges();
        }
        public void Remove(string name, string surname)
        {
            var client = _context.Clients.Find(name, surname);
            if(client!=null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }
        public void AddNewAdress(Adress adress)
        {
            _context.Adresses.Add(adress);
            _context.SaveChanges();
        }
    }

}
