using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using DVD_Service.DTO;
using DVD_Service.Interfaces;
using DVD_Service.Repository;
using DVD_Service.Logging;

namespace DVD_Service.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class LoggingController : ApiController
  {
    public LoggingController()
    {
      this.Repository = new LoggingRepository();
    }

    public LoggingController(ILoggingRepository repository)
    {
      this.Repository = repository;
    }

    [HttpGet]
    [Route("Logging/Hello")]
    public string Hello()
    {
      return Repository.Hello();
    }

    [HttpPost]
    [Route("Logging/LogMessage")]
    public bool LogMessage([FromBody]LoggingRequest request)
    {
      return Logger.WriteToLog(request);
    }

    [HttpGet]
    [Route("Logging/GetLogFileRecords")]
    public List<string> GetLogFileRecords()
    {
      List<string> data = Repository.GetLogFileRecords();
      return data;
    }

    public ILoggingRepository Repository { get; set; }
  }
}
