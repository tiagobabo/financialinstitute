﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.FinancialInstitute {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FinancialInstitute.IFinancialInstituteOps")]
    public interface IFinancialInstituteOps {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFinancialInstituteOps/ReportToInstitute")]
        void ReportToInstitute(string time, int client, string email, int op, int type, int quantity, int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFinancialInstituteOpsChannel : Server.FinancialInstitute.IFinancialInstituteOps, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FinancialInstituteOpsClient : System.ServiceModel.ClientBase<Server.FinancialInstitute.IFinancialInstituteOps>, Server.FinancialInstitute.IFinancialInstituteOps {
        
        public FinancialInstituteOpsClient() {
        }
        
        public FinancialInstituteOpsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FinancialInstituteOpsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FinancialInstituteOpsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FinancialInstituteOpsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ReportToInstitute(string time, int client, string email, int op, int type, int quantity, int id) {
            base.Channel.ReportToInstitute(time, client, email, op, type, quantity, id);
        }
    }
}
