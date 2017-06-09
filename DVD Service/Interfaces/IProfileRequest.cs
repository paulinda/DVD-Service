using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_Service.Interfaces
{
  public interface IProfileRequest
  {
    int UserID { get; set; }
    int UserGuid { get; set; }
  }
}
