using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace FileServer {
    [MessageContract]
    public class ResponseFileDownload {
        [MessageHeader]
        public string FileName;//File Name

        [MessageHeader]
        public long Length;

        [MessageBodyMember]
        public System.IO.Stream FileByteStream;

        [MessageHeader]
        public long byteStart = 0;

        public void Dispose() {//Destroy the Stream
            if(FileByteStream != null) {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
