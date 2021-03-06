﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KassaExpert.FonConnector.Lib.UidAbfrageService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://finanzonline.bmf.gv.at/fon/ws/uidAbfrage", ConfigurationName="KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfragePort")]
    internal interface uidAbfragePort
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="uidAbfrage", ReplyAction="*")]
        System.Threading.Tasks.Task<KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfrageServiceResponse> uidAbfrageAsync(KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfrageServiceRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    internal partial class uidAbfrageServiceRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="uidAbfrageServiceRequest", Namespace="https://finanzonline.bmf.gv.at/fon/ws/uidAbfrage", Order=0)]
        public KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfrageServiceRequestBody Body;
        
        public uidAbfrageServiceRequest()
        {
        }
        
        public uidAbfrageServiceRequest(KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfrageServiceRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="https://finanzonline.bmf.gv.at/fon/ws/uidAbfrage")]
    internal partial class uidAbfrageServiceRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string tid;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string benid;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string id;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string uid_tn;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string uid;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string stufe;
        
        public uidAbfrageServiceRequestBody()
        {
        }
        
        public uidAbfrageServiceRequestBody(string tid, string benid, string id, string uid_tn, string uid, string stufe)
        {
            this.tid = tid;
            this.benid = benid;
            this.id = id;
            this.uid_tn = uid_tn;
            this.uid = uid;
            this.stufe = stufe;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    internal partial class uidAbfrageServiceResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="uidAbfrageServiceResponse", Namespace="https://finanzonline.bmf.gv.at/fon/ws/uidAbfrage", Order=0)]
        public KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfrageServiceResponseBody Body;
        
        public uidAbfrageServiceResponse()
        {
        }
        
        public uidAbfrageServiceResponse(KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfrageServiceResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="https://finanzonline.bmf.gv.at/fon/ws/uidAbfrage")]
    internal partial class uidAbfrageServiceResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int rc;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string msg;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string name;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string adrz1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string adrz2;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string adrz3;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string adrz4;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string adrz5;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string adrz6;
        
        public uidAbfrageServiceResponseBody()
        {
        }
        
        public uidAbfrageServiceResponseBody(int rc, string msg, string name, string adrz1, string adrz2, string adrz3, string adrz4, string adrz5, string adrz6)
        {
            this.rc = rc;
            this.msg = msg;
            this.name = name;
            this.adrz1 = adrz1;
            this.adrz2 = adrz2;
            this.adrz3 = adrz3;
            this.adrz4 = adrz4;
            this.adrz5 = adrz5;
            this.adrz6 = adrz6;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    internal interface uidAbfragePortChannel : KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfragePort, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    internal partial class uidAbfragePortClient : System.ServiceModel.ClientBase<KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfragePort>, KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfragePort
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public uidAbfragePortClient() : 
                base(uidAbfragePortClient.GetDefaultBinding(), uidAbfragePortClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.uidAbfrage.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public uidAbfragePortClient(EndpointConfiguration endpointConfiguration) : 
                base(uidAbfragePortClient.GetBindingForEndpoint(endpointConfiguration), uidAbfragePortClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public uidAbfragePortClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(uidAbfragePortClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public uidAbfragePortClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(uidAbfragePortClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public uidAbfragePortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfrageServiceResponse> uidAbfrageAsync(KassaExpert.FonConnector.Lib.UidAbfrageService.uidAbfrageServiceRequest request)
        {
            return base.Channel.uidAbfrageAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.uidAbfrage))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.uidAbfrage))
            {
                return new System.ServiceModel.EndpointAddress("https://finanzonline.bmf.gv.at/fonuid/ws/uidAbfrage/");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return uidAbfragePortClient.GetBindingForEndpoint(EndpointConfiguration.uidAbfrage);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return uidAbfragePortClient.GetEndpointAddress(EndpointConfiguration.uidAbfrage);
        }
        
        public enum EndpointConfiguration
        {
            
            uidAbfrage,
        }
    }
}
