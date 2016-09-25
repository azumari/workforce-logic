﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Workforce.Logic.Grace.Tests.GraceServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GraceServiceReference.IGraceService")]
    public interface IGraceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetComplexes", ReplyAction="http://tempuri.org/IGraceService/GetComplexesResponse")]
        Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao[] GetComplexes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetComplexes", ReplyAction="http://tempuri.org/IGraceService/GetComplexesResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao[]> GetComplexesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetApartments", ReplyAction="http://tempuri.org/IGraceService/GetApartmentsResponse")]
        Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao[] GetApartments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetApartments", ReplyAction="http://tempuri.org/IGraceService/GetApartmentsResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao[]> GetApartmentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetHousingData", ReplyAction="http://tempuri.org/IGraceService/GetHousingDataResponse")]
        Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao[] GetHousingData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetHousingData", ReplyAction="http://tempuri.org/IGraceService/GetHousingDataResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao[]> GetHousingDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetStatuses", ReplyAction="http://tempuri.org/IGraceService/GetStatusesResponse")]
        Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao[] GetStatuses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetStatuses", ReplyAction="http://tempuri.org/IGraceService/GetStatusesResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao[]> GetStatusesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertApartment", ReplyAction="http://tempuri.org/IGraceService/InsertApartmentResponse")]
        bool InsertApartment(Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao newapt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertApartment", ReplyAction="http://tempuri.org/IGraceService/InsertApartmentResponse")]
        System.Threading.Tasks.Task<bool> InsertApartmentAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao newapt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertHousingData", ReplyAction="http://tempuri.org/IGraceService/InsertHousingDataResponse")]
        bool InsertHousingData(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao newhdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertHousingData", ReplyAction="http://tempuri.org/IGraceService/InsertHousingDataResponse")]
        System.Threading.Tasks.Task<bool> InsertHousingDataAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao newhdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertHousingComplex", ReplyAction="http://tempuri.org/IGraceService/InsertHousingComplexResponse")]
        bool InsertHousingComplex(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao newhcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertHousingComplex", ReplyAction="http://tempuri.org/IGraceService/InsertHousingComplexResponse")]
        System.Threading.Tasks.Task<bool> InsertHousingComplexAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao newhcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertStatus", ReplyAction="http://tempuri.org/IGraceService/InsertStatusResponse")]
        bool InsertStatus(Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao newstatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertStatus", ReplyAction="http://tempuri.org/IGraceService/InsertStatusResponse")]
        System.Threading.Tasks.Task<bool> InsertStatusAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao newstatus);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGraceServiceChannel : Workforce.Logic.Grace.Tests.GraceServiceReference.IGraceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GraceServiceClient : System.ServiceModel.ClientBase<Workforce.Logic.Grace.Tests.GraceServiceReference.IGraceService>, Workforce.Logic.Grace.Tests.GraceServiceReference.IGraceService {
        
        public GraceServiceClient() {
        }
        
        public GraceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GraceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GraceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GraceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao[] GetComplexes() {
            return base.Channel.GetComplexes();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao[]> GetComplexesAsync() {
            return base.Channel.GetComplexesAsync();
        }
        
        public Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao[] GetApartments() {
            return base.Channel.GetApartments();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao[]> GetApartmentsAsync() {
            return base.Channel.GetApartmentsAsync();
        }
        
        public Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao[] GetHousingData() {
            return base.Channel.GetHousingData();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao[]> GetHousingDataAsync() {
            return base.Channel.GetHousingDataAsync();
        }
        
        public Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao[] GetStatuses() {
            return base.Channel.GetStatuses();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao[]> GetStatusesAsync() {
            return base.Channel.GetStatusesAsync();
        }
        
        public bool InsertApartment(Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao newapt) {
            return base.Channel.InsertApartment(newapt);
        }
        
        public System.Threading.Tasks.Task<bool> InsertApartmentAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao newapt) {
            return base.Channel.InsertApartmentAsync(newapt);
        }
        
        public bool InsertHousingData(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao newhdata) {
            return base.Channel.InsertHousingData(newhdata);
        }
        
        public System.Threading.Tasks.Task<bool> InsertHousingDataAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao newhdata) {
            return base.Channel.InsertHousingDataAsync(newhdata);
        }
        
        public bool InsertHousingComplex(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao newhcomplex) {
            return base.Channel.InsertHousingComplex(newhcomplex);
        }
        
        public System.Threading.Tasks.Task<bool> InsertHousingComplexAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao newhcomplex) {
            return base.Channel.InsertHousingComplexAsync(newhcomplex);
        }
        
        public bool InsertStatus(Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao newstatus) {
            return base.Channel.InsertStatus(newstatus);
        }
        
        public System.Threading.Tasks.Task<bool> InsertStatusAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao newstatus) {
            return base.Channel.InsertStatusAsync(newstatus);
        }
    }
}
