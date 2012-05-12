using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace FinancialInstituteOps
{
    public class FinancialInstituteOps : IFinancialInstituteOps
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public void ReportToSupervisor(string message)
        {
            Console.WriteLine(message);
        }
    }
}
