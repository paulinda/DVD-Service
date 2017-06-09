using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DVD_Service.DTO;

namespace DVD_Service.Interfaces
{
  public interface IAuthenticationRepository
  {
    string Hello();
    AuthenticationResponse Login(AuthenticationRequest request);
    AuthenticationResponse Logout(Guid authGuid);
    AuthenticationResponse Register(AuthenticationRequest request);
  }
}
