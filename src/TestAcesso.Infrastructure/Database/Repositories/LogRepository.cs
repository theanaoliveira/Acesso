using AutoMapper;
using System.Collections.Generic;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Domain.Logs;

namespace TestAcesso.Infrastructure.Database.Repositories
{
    internal class LogRepository : ILogRepository
    {
        private readonly IMapper mapper;

        public LogRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Add(List<Log> logs)
        {
            using var context = new Context();

            context.Logs.AddRange(mapper.Map<List<Entities.Log>>(logs));
            context.SaveChanges();
        }
    }
}
