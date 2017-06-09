using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DVD_Service.Interfaces;
using static DVD_Service.Logging.Logger;

namespace DVD_Service.DTO
{
  public class LoggingRequest: ILoggingRequest
  {
    public LoggingTypes LogType { get; set; }
    public string Message { get; set; }
  }
}