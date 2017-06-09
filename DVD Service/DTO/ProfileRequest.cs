using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DVD_Service.Interfaces;

namespace DVD_Service.DTO
{
  public class ProfileRequest: IProfileRequest
  {
    public int UserID { get; set; }
    public int UserGuid { get; set; }
  }
}