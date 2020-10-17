using System;
using System.Collections.Generic;
using System.Linq;
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
        public int AddNew(Client client)
        {
            client.IsActive = true;
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client.Id;
        }
        public void Update (Client client)
        {
            _context.Attach(client);
            _context.Entry(client).Property("Company").IsModified = true;
            _context.Entry(client).Property("Name").IsModified = true;
            _context.Entry(client).Property("Surname").IsModified = true;
            _context.Entry(client).Property("NIP").IsModified = true;
            _context.SaveChanges();
        }

        public void UpdateContact(ClientData client)
        {
            _context.Attach(client);
            _context.Entry(client).Property("Email").IsModified = true;
            _context.Entry(client).Property("PhoneNumber").IsModified = true;
            _context.SaveChanges();
        }

        public void UpdateAddress(ClientAdress client)
        {
            _context.Attach(client);
            _context.Entry(client).Property("Street").IsModified = true;
            _context.Entry(client).Property("NumberOfHome").IsModified = true;
            _context.Entry(client).Property("NumberOfFlat").IsModified = true;
            _context.Entry(client).Property("ZipCode").IsModified = true;
            _context.Entry(client).Property("City").IsModified = true;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var client = _context.Clients.Find(id);
            if(client!=null)
            {
                client.IsActive = false;
                //_context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }
        public int AddNewAdress(ClientAdress adress)
        {
            _context.ClientAdresses.Add(adress);
            _context.SaveChanges();
            return adress.Id;
        }
        public int AddNewContactDetail(ClientData clientData)
        {
            _context.ClientDatas.Add(clientData);
            _context.SaveChanges();
            return clientData.Id;
        }

        public Client GetClient(int clientId)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == clientId);
        }

        public IQueryable<Client> GetAllActiveClients()
        {
            return _context.Clients.Where(c => c.IsActive);
        }

        public IQueryable<Client> GetAllClients()
        {
            return _context.Clients;
        }

        public Basket GetClientBasket(int clientId)
        {
            return _context.Baskets.FirstOrDefault(c => c.ClientId == clientId && c.IsRealised==false);
        }

        public IQueryable<ClientData> GetClientContacts(int clientId)
        {
            return _context.ClientDatas.Where(c => c.ClientId == clientId);
        }

        public IQueryable<ClientAdress> GetClientAdress(int clientId)
        {
            return _context.ClientAdresses.Where(c => c.ClientId == clientId);
        }

        public IQueryable<Basket> GetBasketHistory(int clientId)
        {
            return _context.Baskets.Where(c => c.ClientId == clientId && c.IsRealised==true);
        }

        public void RemoveAddress(int id)
        {
            var address = _context.ClientAdresses.FirstOrDefault(c => c.Id == id);
            if(address!=null)
            {
                _context.ClientAdresses.Remove(address);
            }
            _context.SaveChanges();
        }

        public void RemoveContact(int id)
        {
            var contact = _context.ClientDatas.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                _context.ClientDatas.Remove(contact);
            }
            _context.SaveChanges();
        }
    }

}
