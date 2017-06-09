using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DVD_Service.Logging.Logger;

namespace DVD_Service.Interfaces
{
  public interface ILoggingRequest
  {
    LoggingTypes LogType { get; set; }
    string Message { get; set; }
  }
}
