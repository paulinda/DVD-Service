using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DVD_Service.DTO;
using DVD_Service.Interfaces;
using DVD_Service.Logging;

namespace DVD_Service.Repository
{
  public class LoggingRepository: ILoggingRepository
  {
    public string Hello()
    {
      return "Hello from the Logging controller.";
    }

    public bool LogMessage(LoggingRequest request)
    {
      return true;
    }
    public List<string> GetLogFileRecords()
    {
      return Logger.GetLogFileRecords();
    }
  }
}