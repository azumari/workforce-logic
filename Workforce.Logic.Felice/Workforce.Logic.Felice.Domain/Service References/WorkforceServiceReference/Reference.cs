﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Workforce.Logic.Felice.Domain.WorkforceServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WorkforceServiceReference.IFeliceService")]
    public interface IFeliceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeliceService/DoWork", ReplyAction="http://tempuri.org/IFeliceService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeliceService/DoWork", ReplyAction="http://tempuri.org/IFeliceService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFeliceServiceChannel : Workforce.Logic.Felice.Domain.WorkforceServiceReference.IFeliceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FeliceServiceClient : System.ServiceModel.ClientBase<Workforce.Logic.Felice.Domain.WorkforceServiceReference.IFeliceService>, Workforce.Logic.Felice.Domain.WorkforceServiceReference.IFeliceService {
        
        public FeliceServiceClient() {
        }
        
        public FeliceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FeliceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FeliceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FeliceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
    }
}
