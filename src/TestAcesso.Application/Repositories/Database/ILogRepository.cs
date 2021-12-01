using System;
using System.Collections.Generic;
using System.Text;
using TestAcesso.Domain.Logs;

namespace TestAcesso.Application.Repositories.Database
{
    public interface ILogRepository
    {
        void Add(List<Log> logs);
    }
}
