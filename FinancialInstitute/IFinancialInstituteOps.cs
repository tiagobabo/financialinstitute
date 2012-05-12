using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace FinancialInstituteOps
{
    [ServiceContract]
    public interface IFinancialInstituteOps
    {
        [OperationContract(IsOneWay = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ReportToSupervisor(string message);
    }
}
