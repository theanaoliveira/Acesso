using System;
using System.Collections.Generic;
using System.Text;

namespace TestAcesso.Application.UseCases.SendTransfer
{
    public interface ITransferUseCase
    {
        void Execute(TransferUcRequest request);
    }
}
