using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace FileServer {
    [MessageContract]
    public class RequestFile {
        [MessageBodyMember]
        public string FileName;

        [MessageBodyMember]
        public long byteStart = 0;
    }
}
