﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMSMVC.Web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
