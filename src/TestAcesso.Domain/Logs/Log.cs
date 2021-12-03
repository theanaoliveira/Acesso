using System;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Domain.Logs
{
    public class Log : Entity
    {
        public string Message { get; private set; }
        public LogType Type { get; private set; }
        public DateTime LogDate { get; private set; }

        protected Log() { }

        public Log(string message, LogType type, DateTime logDate)
        {
            Id = Guid.NewGuid();
            Message = message;
            Type = type;
            LogDate = logDate;
        }

        public static Log AddLog(string message, LogType type, DateTime logDate)
           => new Log(message, type, logDate);
    }
}
