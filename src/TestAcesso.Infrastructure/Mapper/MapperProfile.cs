using AutoMapper;
using TestAcesso.Domain.Accounts;
using TestAcesso.Domain.Logs;

namespace TestAcesso.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, Services.Entities.Account>().ReverseMap();
            CreateMap<AccountTransfer, Database.Entities.AccountTransfer>().ReverseMap();
            CreateMap<Transaction, Database.Entities.Transaction>().ReverseMap();
            CreateMap<Log, Database.Entities.Log>().ReverseMap();
        }
    }
}
