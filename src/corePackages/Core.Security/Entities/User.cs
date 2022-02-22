﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class User : Entity
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    

        public User(int id, string email, byte[] passwordSalt, byte[] passwordHash, bool status): this()
        {
            Id = id;
            //FirstName = firstName;
            //LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
        }

        public User()
        {

        }
    }
}
