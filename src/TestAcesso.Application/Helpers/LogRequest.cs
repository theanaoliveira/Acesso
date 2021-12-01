using System;
using System.Collections.Generic;
using TestAcesso.Domain.Enums;
using TestAcesso.Domain.Logs;

namespace TestAcesso.Application.Helpers
{
    public abstract class LogRequest
    {
        protected LogRequest()
        {
            Logs = new List<Log>();
        }

        public List<Log> Logs { get; set; }

        public void AddProcessLog(string message)
           => Logs.Add(Log.AddLog(message, LogType.Process, DateTime.UtcNow));

        public void AddErrorLog(string message)
            => Logs.Add(Log.AddLog(message, LogType.Error, DateTime.UtcNow));
    }
}
