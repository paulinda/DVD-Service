using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DVD_Service.Interfaces;

namespace DVD_Service.DTO
{
  public class AuthenticationRequest: IAuthenticationRequest
  {
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
  }
}