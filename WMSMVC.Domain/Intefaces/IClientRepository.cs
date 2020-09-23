using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Domain.Model;

namespace WMSMVC.Domain.Intefaces
{
    public interface IClientRepository
    {
        void AddNew(string name, string surname, DateTime birth, string email, string number);
        void Remove(string name, string surname);
        void AddNewAdress(Adress adress);
    }
}
