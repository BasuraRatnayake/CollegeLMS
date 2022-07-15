using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FileServer {
    public class FileControl:IFileControl {
        public ResponseFileDownload DownloadFile(RequestFile request) {//Download Single File from server
            ResponseFileDownload result = new ResponseFileDownload();

            FileStream stream = this.GetFileStream(Path.GetFullPath(request.FileName));
            stream.Seek(request.byteStart, SeekOrigin.Begin);
            result.FileName = request.FileName;
            result.Length = stream.Length;
            result.FileByteStream = stream;

            return result;

        }
        private FileStream GetFileStream(string filePath) {//Get File Stream
            FileInfo fileInfo = new FileInfo(filePath);

            if(!fileInfo.Exists)
                throw new FileNotFoundException("File not found");

            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }
        public void UploadFile(ResponseFile request) {//Upload Single file to server

            string filePath = Path.GetFullPath("Files//"+request.Directory+"//"+request.FileName);

            int chunkSize = 2048;
            byte[] buffer = new byte[chunkSize];

            FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write);

            do {
                int readbyte = request.FileByteStream.Read(buffer, 0, chunkSize);
                if(readbyte == 0)
                    break;

                stream.Write(buffer, 0, readbyte);
            } while(true);
            stream.Close();
        }

        public Boolean deleteFile(String filename) {//Delete file from server
            if(File.Exists(filename)) {//Check if file exists
                File.Delete(filename);
                if(!File.Exists(filename))//Check if file deleted
                    return true;
            }
            return false;
        }
    }
}
