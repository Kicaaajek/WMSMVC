using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Domain.Model;
using WMSMVC.Web.Models;

namespace WMSMVC.Domain.Intefaces
{
    public interface IClientRepository
    {
        int AddNew(Client client);
        void Remove(int id);
        void Update(Client client);
        void UpdateContact(ClientData client);
        void UpdateAddress(ClientAdress client);
        int AddNewAdress(ClientAdress adress);
        int AddNewContactDetail(ClientData clientData);
        Client GetClient(int Id);
        IQueryable<Client> GetAllActiveClients();
        IQueryable<Client> GetAllClients();
        IQueryable<ClientData> GetClientContacts(int clientId);
        IQueryable<ClientAdress> GetClientAdress(int clientId);
        Basket GetClientBasket(int clientId);
        IQueryable<Basket> GetBasketHistory(int clientId);
        void RemoveAddress(int id);
        void RemoveContact(int id);
    }
}
