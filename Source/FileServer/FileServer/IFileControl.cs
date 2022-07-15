using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FileServer {
    [ServiceContract]
    public interface IFileControl {
        [OperationContract()]
        void UploadFile(ResponseFile request);//Upload File to Server

        [OperationContract]
        ResponseFileDownload DownloadFile(RequestFile request);//Download FIle from Server

        [OperationContract]
        Boolean deleteFile(String filename);//Delete File from server
    }
}
