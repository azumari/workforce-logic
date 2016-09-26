﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Workforce.Logic.Grace.Domain.GraceServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HousingComplexDao", Namespace="http://schemas.datacontract.org/2004/07/Workforce.Data.Grace.Soap.ServiceModels")]
    [System.SerializableAttribute()]
    public partial class HousingComplexDao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActiveBitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HotelIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsHotelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneNumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ActiveBit {
            get {
                return this.ActiveBitField;
            }
            set {
                if ((this.ActiveBitField.Equals(value) != true)) {
                    this.ActiveBitField = value;
                    this.RaisePropertyChanged("ActiveBit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int HotelID {
            get {
                return this.HotelIDField;
            }
            set {
                if ((this.HotelIDField.Equals(value) != true)) {
                    this.HotelIDField = value;
                    this.RaisePropertyChanged("HotelID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsHotel {
            get {
                return this.IsHotelField;
            }
            set {
                if ((this.IsHotelField.Equals(value) != true)) {
                    this.IsHotelField = value;
                    this.RaisePropertyChanged("IsHotel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PhoneNumber {
            get {
                return this.PhoneNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneNumberField, value) != true)) {
                    this.PhoneNumberField = value;
                    this.RaisePropertyChanged("PhoneNumber");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ApartmentDao", Namespace="http://schemas.datacontract.org/2004/07/Workforce.Data.Grace.Soap.ServiceModels")]
    [System.SerializableAttribute()]
    public partial class ApartmentDao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActiveBitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CurrentCapacityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> GenderIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> HotelIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MaxCapacityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoomIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoomNumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ActiveBit {
            get {
                return this.ActiveBitField;
            }
            set {
                if ((this.ActiveBitField.Equals(value) != true)) {
                    this.ActiveBitField = value;
                    this.RaisePropertyChanged("ActiveBit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CurrentCapacity {
            get {
                return this.CurrentCapacityField;
            }
            set {
                if ((this.CurrentCapacityField.Equals(value) != true)) {
                    this.CurrentCapacityField = value;
                    this.RaisePropertyChanged("CurrentCapacity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> GenderID {
            get {
                return this.GenderIDField;
            }
            set {
                if ((this.GenderIDField.Equals(value) != true)) {
                    this.GenderIDField = value;
                    this.RaisePropertyChanged("GenderID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> HotelID {
            get {
                return this.HotelIDField;
            }
            set {
                if ((this.HotelIDField.Equals(value) != true)) {
                    this.HotelIDField = value;
                    this.RaisePropertyChanged("HotelID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxCapacity {
            get {
                return this.MaxCapacityField;
            }
            set {
                if ((this.MaxCapacityField.Equals(value) != true)) {
                    this.MaxCapacityField = value;
                    this.RaisePropertyChanged("MaxCapacity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoomID {
            get {
                return this.RoomIDField;
            }
            set {
                if ((this.RoomIDField.Equals(value) != true)) {
                    this.RoomIDField = value;
                    this.RaisePropertyChanged("RoomID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoomNumber {
            get {
                return this.RoomNumberField;
            }
            set {
                if ((this.RoomNumberField.Equals(value) != true)) {
                    this.RoomNumberField = value;
                    this.RaisePropertyChanged("RoomNumber");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HousingDataDao", Namespace="http://schemas.datacontract.org/2004/07/Workforce.Data.Grace.Soap.ServiceModels")]
    [System.SerializableAttribute()]
    public partial class HousingDataDao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AssociateIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime MoveInDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime MoveOutDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> RoomIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StatusIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AssociateID {
            get {
                return this.AssociateIDField;
            }
            set {
                if ((this.AssociateIDField.Equals(value) != true)) {
                    this.AssociateIDField = value;
                    this.RaisePropertyChanged("AssociateID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime MoveInDate {
            get {
                return this.MoveInDateField;
            }
            set {
                if ((this.MoveInDateField.Equals(value) != true)) {
                    this.MoveInDateField = value;
                    this.RaisePropertyChanged("MoveInDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime MoveOutDate {
            get {
                return this.MoveOutDateField;
            }
            set {
                if ((this.MoveOutDateField.Equals(value) != true)) {
                    this.MoveOutDateField = value;
                    this.RaisePropertyChanged("MoveOutDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> RoomID {
            get {
                return this.RoomIDField;
            }
            set {
                if ((this.RoomIDField.Equals(value) != true)) {
                    this.RoomIDField = value;
                    this.RaisePropertyChanged("RoomID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StatusID {
            get {
                return this.StatusIDField;
            }
            set {
                if ((this.StatusIDField.Equals(value) != true)) {
                    this.StatusIDField = value;
                    this.RaisePropertyChanged("StatusID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StatusDao", Namespace="http://schemas.datacontract.org/2004/07/Workforce.Data.Grace.Soap.ServiceModels")]
    [System.SerializableAttribute()]
    public partial class StatusDao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusColorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StatusIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusColor {
            get {
                return this.StatusColorField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusColorField, value) != true)) {
                    this.StatusColorField = value;
                    this.RaisePropertyChanged("StatusColor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StatusID {
            get {
                return this.StatusIDField;
            }
            set {
                if ((this.StatusIDField.Equals(value) != true)) {
                    this.StatusIDField = value;
                    this.RaisePropertyChanged("StatusID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusMessage {
            get {
                return this.StatusMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusMessageField, value) != true)) {
                    this.StatusMessageField = value;
                    this.RaisePropertyChanged("StatusMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteApartment", ReplyAction="http://tempuri.org/IGraceService/DeleteApartmentResponse")]
        bool DeleteApartment(Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao apt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteApartment", ReplyAction="http://tempuri.org/IGraceService/DeleteApartmentResponse")]
        System.Threading.Tasks.Task<bool> DeleteApartmentAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao apt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteHousingData", ReplyAction="http://tempuri.org/IGraceService/DeleteHousingDataResponse")]
        bool DeleteHousingData(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao hdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteHousingData", ReplyAction="http://tempuri.org/IGraceService/DeleteHousingDataResponse")]
        System.Threading.Tasks.Task<bool> DeleteHousingDataAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao hdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteHousingComplex", ReplyAction="http://tempuri.org/IGraceService/DeleteHousingComplexResponse")]
        bool DeleteHousingComplex(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao hcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteHousingComplex", ReplyAction="http://tempuri.org/IGraceService/DeleteHousingComplexResponse")]
        System.Threading.Tasks.Task<bool> DeleteHousingComplexAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao hcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteStatus", ReplyAction="http://tempuri.org/IGraceService/DeleteStatusResponse")]
        bool DeleteStatus(Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteStatus", ReplyAction="http://tempuri.org/IGraceService/DeleteStatusResponse")]
        System.Threading.Tasks.Task<bool> DeleteStatusAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao status);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGraceServiceChannel : Workforce.Logic.Grace.Domain.GraceServiceReference.IGraceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GraceServiceClient : System.ServiceModel.ClientBase<Workforce.Logic.Grace.Domain.GraceServiceReference.IGraceService>, Workforce.Logic.Grace.Domain.GraceServiceReference.IGraceService {
        
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
        
        public bool DeleteApartment(Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao apt) {
            return base.Channel.DeleteApartment(apt);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteApartmentAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.ApartmentDao apt) {
            return base.Channel.DeleteApartmentAsync(apt);
        }
        
        public bool DeleteHousingData(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao hdata) {
            return base.Channel.DeleteHousingData(hdata);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteHousingDataAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingDataDao hdata) {
            return base.Channel.DeleteHousingDataAsync(hdata);
        }
        
        public bool DeleteHousingComplex(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao hcomplex) {
            return base.Channel.DeleteHousingComplex(hcomplex);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteHousingComplexAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.HousingComplexDao hcomplex) {
            return base.Channel.DeleteHousingComplexAsync(hcomplex);
        }
        
        public bool DeleteStatus(Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao status) {
            return base.Channel.DeleteStatus(status);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteStatusAsync(Workforce.Logic.Grace.Domain.GraceServiceReference.StatusDao status) {
            return base.Channel.DeleteStatusAsync(status);
        }
    }
}
