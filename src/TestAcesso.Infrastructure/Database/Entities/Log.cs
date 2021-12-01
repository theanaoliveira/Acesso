using System;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Infrastructure.Database.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public LogType Type { get; set; }
        public DateTime LogDate { get; set; }
    }
}
