using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DVD_Service.Interfaces;

namespace DVD_Service.DTO
{
  public class AuthenticationResponse: IAuthenticationResponse
  {
    public Guid Auth_Token { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Success { get; set; }
  }
}