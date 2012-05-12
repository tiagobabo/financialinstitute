using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace FinancialOps
{

    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IFinancialOps {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void TransferAtoB(int acctA, int acctB, double amount);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void TransferBtoA(int acctB, int acctA, double amount);
    }
}
