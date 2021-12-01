using FluentValidation;
using System;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Domain.Validator
{
    public class AccountTransferValidator : AbstractValidator<AccountTransfer>
    {
        public AccountTransferValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEqual(new Guid());
            RuleFor(r => r.AccountOrigin).NotNull().NotEmpty();
            RuleFor(r => r.AccountDestination).NotNull().NotEmpty();
            RuleFor(r => r.Value).NotNull().GreaterThan(0);
            RuleFor(r => r.Status).IsInEnum();
        }
    }
}
