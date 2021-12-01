using FluentValidation;
using System;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Domain.Validator
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEqual(new Guid());
            RuleFor(r => r.AccountNumber).NotNull().NotEmpty();
            RuleFor(r => r.Value).NotNull().GreaterThan(0);
            RuleFor(r => r.Type).IsInEnum();
        }
    }
}
