using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace FinancialOps
{
    class FinancialOps : IFinancialOps
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public void TransferAtoB(int acctA, int acctB, double amount)
        {
            
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void TransferBtoA(int acctB, int acctA, double amount)
        {
           
        }
    }
}
