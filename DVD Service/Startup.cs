using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(DVD_Service.Startup))]
namespace DVD_Service
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      // This server will be accessed by clients from other domains, so
      //  we open up CORS
      //
      app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

      // Add SignalR to the OWIN pipeline
      //
      app.MapSignalR();

      // Build up the WebAPI middleware
      //
      var httpConfig = new HttpConfiguration();

      httpConfig.MapHttpAttributeRoutes();

      app.UseWebApi(httpConfig);
    }
  }
}