﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workboard.Application.DTO
{
    public class LoginUserDTO
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
