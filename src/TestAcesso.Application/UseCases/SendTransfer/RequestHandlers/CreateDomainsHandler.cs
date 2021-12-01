using System;
using System.Linq;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Application.UseCases.SendTransfer.RequestHandlers
{
    public class CreateDomainsHandler : Handler<TransferUcRequest>
    {
        public override void ProcessRequest(TransferUcRequest request)
        {
            request.AddProcessLog($"Mount accountTransfer domain");

            request.AccountTransfer = new AccountTransfer(Guid.NewGuid(),
                request.AccountOrigin,
                request.AccountDest,
                request.Value);

            if (!request.AccountTransfer.Valid)
            {
                var message = $"Domain is invalid: {string.Join(',', request.AccountTransfer.ValidationResult.Errors.Select(s => s.ErrorMessage).ToArray())}";

                request.AddErrorLog(message);
                request.HasError = true;
                request.ErrorMessage = message;

                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
