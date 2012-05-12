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
        Boolean NewOrder(int client, string email, int op, int type, int quantity);

        [OperationContract]
        int GetStatus(int id);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Boolean ChangeOrder(int id, double cotation);

        [OperationContract]
        List<int> GetWaitingRequests();

        [OperationContract]
        List<int> GetRequestsByClient(int client);

    }
}
