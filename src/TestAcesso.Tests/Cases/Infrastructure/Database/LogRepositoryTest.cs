using FluentAssertions;
using System;
using System.Collections.Generic;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Domain.Enums;
using TestAcesso.Domain.Logs;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace TestAcesso.Tests.Cases.Infrastructure.Database
{
    [UseAutofacTestFramework]
    public class LogRepositoryTest
    {
        private readonly ILogRepository logRepository;

        public LogRepositoryTest(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        [Fact]
        public void ShouldAddListLogs()
        {
            var logs = new List<Log> { new Log("", LogType.Process, DateTime.Now) };

            Action act = () => logRepository.Add(logs);

            act.Should().NotThrow();
        }
    }
}
