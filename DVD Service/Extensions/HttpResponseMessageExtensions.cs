using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DVD_Service.Extensions
{
  public static class HttpResponseMessageExtensions
  {
    public static T GetFirstHeaderValueOrDefault<T>(
    this HttpRequestMessage request,
    string headerKey)
    {
      var toReturn = default(T);

      IEnumerable<string> headerValues;

      if (request.Content.Headers.TryGetValues(headerKey, out headerValues))
      {
        var valueString = headerValues.FirstOrDefault();
        if (valueString != null)
        {
          return (T)Convert.ChangeType(valueString, typeof(T));
        }
      }
      return toReturn;
    }
  }
}