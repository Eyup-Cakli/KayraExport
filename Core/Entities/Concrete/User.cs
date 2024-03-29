﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete;

public class User: IEntity
{
    public int UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }
}
