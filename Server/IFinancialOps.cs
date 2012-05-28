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
        Boolean NewOrder(int client, string email, int op, int type, int quantity);

        [OperationContract]
        int GetStatus(int id);

        [OperationContract]
        Boolean ChangeOrder(int id, double cotation, string email);

        [OperationContract]
        List<List<String>> GetRequestsByClient(int client);

    }
}
