using System;
using System.Collections.Generic;
using System.Text;

namespace WMSMVC.Domain.Model
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<WorkersAdress> WorkerAdress { get; set; }
        public virtual ICollection<WorkersData> WorkerData { get; set; }
        public virtual ICollection<WorkDone> WorkDone { get; set; }

    }
}
