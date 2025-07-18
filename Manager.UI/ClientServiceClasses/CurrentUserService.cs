﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.UI.ClientServiceClasses
{
    public class CurrentUserService
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated=>!string.IsNullOrEmpty(Email);
    }
}
