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
        void ReportToInstitute(int client, string email, int op, int type, int quantity);
    }
}
