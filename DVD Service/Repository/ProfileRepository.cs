using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DVD_Service.DTO;
using DVD_Service.Interfaces;

namespace DVD_Service.Repository
{
  public class ProfileRepository: IProfileRepository
  {
    public string Hello()
    {
      return "Hello from the Profile controller.";
    }

    public ProfileResponse GetUserProfile(ProfileRequest request)
    {
      ProfileResponse response = new ProfileResponse();
      return response;
    }
  }
}