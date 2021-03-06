﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DVD_Service.DTO;

namespace DVD_Service.Interfaces
{
  public interface ILoggingRepository
  {
    string Hello();
    bool LogMessage(LoggingRequest request);
    List<string> GetLogFileRecords();
  }
}
