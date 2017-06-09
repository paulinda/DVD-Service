using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using DVD_Service.DTO;
using DVD_Service.Interfaces;

namespace DVD_Service.Logging
{
  public class Logger
  {
    private static bool initialized = false;
    private static string logFilePath = Path.GetPathRoot(Environment.SystemDirectory) + @"home\site\wwwroot\Logs\";
    private static string logFileName = "DVD Service Log.txt";
    private static object semaphore = new object();
    private static bool allowLogging = true;

    public enum LoggingTypes
    {
      Level_OFF = 0,
      Level_ERROR = 1,
      Level_WARN = 2,
      Level_INFO = 3,
      Level_DEBUG = 4,
      Level_VERBOS = 5
    }

    /// <summary>
    /// Method to initialize the logger.
    /// </summary>
    /// <returns>Success value.</returns>
    private static bool Initialize()
    {
      if (initialized) { return true; }

      if (!Directory.Exists(logFilePath))
      {
        Directory.CreateDirectory(logFilePath);
      }

      if (File.Exists(logFilePath + logFileName))
      {
        File.Delete(logFilePath + logFileName);
      }
      initialized = true;
      WriteToLog(LoggingTypes.Level_INFO, "Angular 2 Server has started.");
      return true;
    }

    public static List<string> GetLogFileRecords()
    {
      List<string> records = new List<string>();

      using (StreamReader sr = new StreamReader(logFilePath + logFileName))
      {
        string[] data = sr.ReadToEnd().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        records.AddRange(data);
        //records.Add(sr.ReadToEnd());
      }
      return records;
    }

    /// <summary>
    /// Logging from the client.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static bool WriteToLog(LoggingRequest request)
    {
      return WriteToLog(request.LogType, request.Message);
    }

    /// <summary>
    /// Internal logging.
    /// </summary>
    /// <param name="logType"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static bool WriteToLog(LoggingTypes logType, string message)
    {
      if (message == "") { return true; }
      if (!initialized) { Initialize(); }

      switch (logType)
      {
        case LoggingTypes.Level_OFF:
          break;
        case LoggingTypes.Level_ERROR:
          return WriteErrorToLog(message);
        case LoggingTypes.Level_WARN:
          return WriteWarningToLog(message);
        case LoggingTypes.Level_INFO:
          return WriteInfoToLog(message);
        case LoggingTypes.Level_DEBUG:
          return WriteDebugToLog(message);
        case LoggingTypes.Level_VERBOS:
          break;
      }
      return true;
    }

    public static bool WriteDebugToLog(string message)
    {
      string title = DateTime.Now.ToString("MM/dd/yyyy") + " - " + DateTime.Now.ToLongTimeString() + " DEBUG: ";
      return WriteMessageToLog(title, message);
    }

    public static bool WriteInfoToLog(string message)
    {
      string title = DateTime.Now.ToString("MM/dd/yyyy") + " - " + DateTime.Now.ToLongTimeString() + " INFO: ";
      return WriteMessageToLog(title, message);
    }

    public static bool WriteErrorToLog(string message)
    {
      string title = DateTime.Now.ToString("MM/dd/yyyy") + " - " + DateTime.Now.ToLongTimeString() + " ERROR: ";
      return WriteMessageToLog(title, message);
    }

    public static bool WriteWarningToLog(string message)
    {
      string title = DateTime.Now.ToString("MM/dd/yyyy") + " - " + DateTime.Now.ToLongTimeString() + " WARNING: ";
      return WriteMessageToLog(title, message);
    }

    private static bool WriteMessageToLog(string title, string message)
    {
      string fileName = logFilePath + logFileName;
      bool firstLine = true;
      string[] lines;

      lock (semaphore)
      {
        using (StreamWriter sw = new StreamWriter(fileName, true))
        {
          lines = message.Split('\n');
          foreach (string line in lines)
          {
            if (firstLine)
            {
              sw.WriteLine(title + line);
              firstLine = false;
            }
            else
            {
              sw.WriteLine(line.PadLeft(line.Length + title.Length, ' '));
            }
          }
        }
      }
      return true;
    }
  }
}