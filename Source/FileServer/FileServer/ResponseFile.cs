using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace FileServer {
    [MessageContract]
    public class ResponseFile:IDisposable {
        [MessageHeader]
        public string FileName;//File Name

        [MessageHeader]
        public string Directory;//Directory to Where the file needs to be saved

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
