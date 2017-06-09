using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DVD_Service.DTO;
using DVD_Service.Extensions;
using DVD_Service.Interfaces;
using DVD_Service.Repository;

namespace DVD_Service.Controllers
{
    public class AuthenticationController : ApiController
    {
    public AuthenticationController()
    {
      this.Repository = new AuthenticationRepository();
    }

    public AuthenticationController(IAuthenticationRepository repository)
    {
      this.Repository = repository;
    }

    [HttpGet]
    [Route("Authentication/Hello")]
    public string Hello()
    {
      return Repository.Hello();
    }

    [HttpPost]
    [Route("Authentication/Login")]
    public AuthenticationResponse Login([FromBody]AuthenticationRequest request)
    {
      return Repository.Login(request);
    }

    [HttpPost]
    [Route("Authentication/Logout")]
    public AuthenticationResponse Logout()
    {
      Guid guid = GetAuthGuidFromHeader();
      Logging.Logger.WriteInfoToLog("Logout Authorization: " + guid);
      return Repository.Logout(guid);
    }

    [HttpPost]
    [Route("Authentication/Register")]
    public AuthenticationResponse Register([FromBody]AuthenticationRequest request)
    {
      return Repository.Register(request);
    }

    private Guid GetAuthGuidFromHeader()
    {
      var re = Request;
      var headers = re.Headers;

      //if (headers.Contains("Authorization"))
      //{
      //  string token = headers.GetValues("Authorization").First();
      //  Logging.Logger.WriteInfoToLog("Authorization: " + token);
      //}
      //if (headers.Contains("X-Requested-By"))
      //{
      //  string token = headers.GetValues("X-Requested-By").First();
      //  Logging.Logger.WriteInfoToLog("X-Requested-By: " + token);
      //}
      if (headers.Contains("AuthGUID"))
      {
        string token = headers.GetValues("AuthGUID").First();
        Logging.Logger.WriteInfoToLog("AuthGUID: " + token);
      }

      ////Log all headers for testing.
      //foreach (var header in headers)
      //{
      //  Logging.Logger.WriteInfoToLog(header.Key + ": " + header.Value.First());
      //}
      ////End testing.

      try
      {
        IEnumerable<string> headerValues = Request.Headers.GetValues("AuthGUID");
        return Guid.Parse(headerValues.FirstOrDefault());
      }
      catch
      {
        return new Guid();
      }
    }

    public IAuthenticationRepository Repository { get; set; }
  }
}
