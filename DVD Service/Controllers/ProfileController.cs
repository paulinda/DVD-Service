using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DVD_Service.DTO;
using DVD_Service.Interfaces;
using DVD_Service.Repository;


namespace DVD_Service.Controllers
{
  public class ProfileController : ApiController
  {
    public ProfileController()
    {
      this.Repository = new ProfileRepository();
    }

    public ProfileController(IProfileRepository repository)
    {
      this.Repository = repository;
    }

    [HttpGet]
    [Route("Profile/Hello")]
    public string Hello()
    {
      return Repository.Hello();
    }

    [HttpGet]
    [Route("Profile/GetUserProfile")]
    public ProfileResponse GetUserProfile([FromBody]ProfileRequest request)
    {
      return Repository.GetUserProfile(request);
    }

    public IProfileRepository Repository { get; set; }
  }
}
