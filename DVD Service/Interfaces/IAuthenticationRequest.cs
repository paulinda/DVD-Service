﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_Service.Interfaces
{
  public interface IAuthenticationRequest
  {
    string Email { get; set; }
    string Password { get; set; }
  }
}
