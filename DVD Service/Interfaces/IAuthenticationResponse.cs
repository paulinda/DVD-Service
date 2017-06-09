using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_Service.Interfaces
{
  public interface IAuthenticationResponse
  {
    Guid Auth_Token { get; set; }
    bool Success { get; set; }
  }
}
