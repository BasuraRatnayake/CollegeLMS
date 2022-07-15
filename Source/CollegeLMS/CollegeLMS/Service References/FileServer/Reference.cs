﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollegeLMS.FileServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FileServer.IFileControl")]
    public interface IFileControl {
        
        // CODEGEN: Generating message contract since the operation UploadFile is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileControl/UploadFile", ReplyAction="http://tempuri.org/IFileControl/UploadFileResponse")]
        CollegeLMS.FileServer.UploadFileResponse UploadFile(CollegeLMS.FileServer.ResponseFile request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileControl/UploadFile", ReplyAction="http://tempuri.org/IFileControl/UploadFileResponse")]
        System.Threading.Tasks.Task<CollegeLMS.FileServer.UploadFileResponse> UploadFileAsync(CollegeLMS.FileServer.ResponseFile request);
        
        // CODEGEN: Generating message contract since the wrapper name (RequestFile) of message RequestFile does not match the default value (DownloadFile)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileControl/DownloadFile", ReplyAction="http://tempuri.org/IFileControl/DownloadFileResponse")]
        CollegeLMS.FileServer.ResponseFileDownload DownloadFile(CollegeLMS.FileServer.RequestFile request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileControl/DownloadFile", ReplyAction="http://tempuri.org/IFileControl/DownloadFileResponse")]
        System.Threading.Tasks.Task<CollegeLMS.FileServer.ResponseFileDownload> DownloadFileAsync(CollegeLMS.FileServer.RequestFile request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileControl/deleteFile", ReplyAction="http://tempuri.org/IFileControl/deleteFileResponse")]
        bool deleteFile(string filename);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileControl/deleteFile", ReplyAction="http://tempuri.org/IFileControl/deleteFileResponse")]
        System.Threading.Tasks.Task<bool> deleteFileAsync(string filename);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ResponseFile", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ResponseFile {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string Directory;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public long Length;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public long byteStart;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileByteStream;
        
        public ResponseFile() {
        }
        
        public ResponseFile(string Directory, string FileName, long Length, long byteStart, System.IO.Stream FileByteStream) {
            this.Directory = Directory;
            this.FileName = FileName;
            this.Length = Length;
            this.byteStart = byteStart;
            this.FileByteStream = FileByteStream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadFileResponse {
        
        public UploadFileResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RequestFile", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class RequestFile {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public long byteStart;
        
        public RequestFile() {
        }
        
        public RequestFile(string FileName, long byteStart) {
            this.FileName = FileName;
            this.byteStart = byteStart;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ResponseFileDownload", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ResponseFileDownload {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public long Length;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public long byteStart;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileByteStream;
        
        public ResponseFileDownload() {
        }
        
        public ResponseFileDownload(string FileName, long Length, long byteStart, System.IO.Stream FileByteStream) {
            this.FileName = FileName;
            this.Length = Length;
            this.byteStart = byteStart;
            this.FileByteStream = FileByteStream;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFileControlChannel : CollegeLMS.FileServer.IFileControl, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileControlClient : System.ServiceModel.ClientBase<CollegeLMS.FileServer.IFileControl>, CollegeLMS.FileServer.IFileControl {
        
        public FileControlClient() {
        }
        
        public FileControlClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileControlClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileControlClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileControlClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CollegeLMS.FileServer.UploadFileResponse CollegeLMS.FileServer.IFileControl.UploadFile(CollegeLMS.FileServer.ResponseFile request) {
            return base.Channel.UploadFile(request);
        }
        
        public void UploadFile(string Directory, string FileName, long Length, long byteStart, System.IO.Stream FileByteStream) {
            CollegeLMS.FileServer.ResponseFile inValue = new CollegeLMS.FileServer.ResponseFile();
            inValue.Directory = Directory;
            inValue.FileName = FileName;
            inValue.Length = Length;
            inValue.byteStart = byteStart;
            inValue.FileByteStream = FileByteStream;
            CollegeLMS.FileServer.UploadFileResponse retVal = ((CollegeLMS.FileServer.IFileControl)(this)).UploadFile(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CollegeLMS.FileServer.UploadFileResponse> CollegeLMS.FileServer.IFileControl.UploadFileAsync(CollegeLMS.FileServer.ResponseFile request) {
            return base.Channel.UploadFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<CollegeLMS.FileServer.UploadFileResponse> UploadFileAsync(string Directory, string FileName, long Length, long byteStart, System.IO.Stream FileByteStream) {
            CollegeLMS.FileServer.ResponseFile inValue = new CollegeLMS.FileServer.ResponseFile();
            inValue.Directory = Directory;
            inValue.FileName = FileName;
            inValue.Length = Length;
            inValue.byteStart = byteStart;
            inValue.FileByteStream = FileByteStream;
            return ((CollegeLMS.FileServer.IFileControl)(this)).UploadFileAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CollegeLMS.FileServer.ResponseFileDownload CollegeLMS.FileServer.IFileControl.DownloadFile(CollegeLMS.FileServer.RequestFile request) {
            return base.Channel.DownloadFile(request);
        }
        
        public long DownloadFile(ref string FileName, ref long byteStart, out System.IO.Stream FileByteStream) {
            CollegeLMS.FileServer.RequestFile inValue = new CollegeLMS.FileServer.RequestFile();
            inValue.FileName = FileName;
            inValue.byteStart = byteStart;
            CollegeLMS.FileServer.ResponseFileDownload retVal = ((CollegeLMS.FileServer.IFileControl)(this)).DownloadFile(inValue);
            FileName = retVal.FileName;
            byteStart = retVal.byteStart;
            FileByteStream = retVal.FileByteStream;
            return retVal.Length;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CollegeLMS.FileServer.ResponseFileDownload> CollegeLMS.FileServer.IFileControl.DownloadFileAsync(CollegeLMS.FileServer.RequestFile request) {
            return base.Channel.DownloadFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<CollegeLMS.FileServer.ResponseFileDownload> DownloadFileAsync(string FileName, long byteStart) {
            CollegeLMS.FileServer.RequestFile inValue = new CollegeLMS.FileServer.RequestFile();
            inValue.FileName = FileName;
            inValue.byteStart = byteStart;
            return ((CollegeLMS.FileServer.IFileControl)(this)).DownloadFileAsync(inValue);
        }
        
        public bool deleteFile(string filename) {
            return base.Channel.deleteFile(filename);
        }
        
        public System.Threading.Tasks.Task<bool> deleteFileAsync(string filename) {
            return base.Channel.deleteFileAsync(filename);
        }
    }
}
