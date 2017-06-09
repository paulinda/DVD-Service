
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DVD_Service.Interfaces;
using DVD_Service.DTO;

namespace DVD_Service.Repository
{
  public class AuthenticationRepository: IAuthenticationRepository
  {
    private static Guid Auth_Token;

    public string Hello()
    {
      return "Hello from the Authentication controller.";
    }

    public AuthenticationResponse Login(AuthenticationRequest request)
    {
      //Need to do actual login here.
      AuthenticationResponse response = new AuthenticationResponse();
      response.Auth_Token = Guid.NewGuid();
      response.FirstName = "Paul";
      response.LastName = "Sorensen";
      response.Success = true;
      Auth_Token = response.Auth_Token;
      Logging.Logger.WriteInfoToLog("Login Generated Authorization: " + response.Auth_Token);
      return response;
    }

    public AuthenticationResponse Logout(Guid authGuid)
    {
      AuthenticationResponse response = new AuthenticationResponse();
      response.Auth_Token = Guid.NewGuid();
      response.FirstName = "Paul";
      response.LastName = "Sorensen";
      response.Success = true;
      return response;
    }

    public AuthenticationResponse Register(AuthenticationRequest request)
    {
      //Need to do actual registration here.
      AuthenticationResponse response = new AuthenticationResponse();
      response.Auth_Token = Guid.NewGuid();
      response.FirstName = "Paul";
      response.LastName = "Sorensen";
      response.Success = true;
      return response;
    }
  }
}