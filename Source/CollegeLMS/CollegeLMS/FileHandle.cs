using CollegeLMS.FileServer;
using System;
using System.Drawing;
using System.IO;

namespace CollegeLMS{
    public class FileHandle{

        FileControlClient fileServer = new FileControlClient();//File Server Connection

        private Stream inputStream = null;

        private long startlength = 0;
        private long length = 0;

        public Image buildImage(String filePath){//Download Bytes and Form an Image
            length = fileServer.DownloadFile(ref filePath, ref startlength, out inputStream);
            FileStream writeStream = new System.IO.FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            int chunkSize = 2048;
            byte[] buffer = new byte[chunkSize];
            do{
                int bytesRead = inputStream.Read(buffer, 0, chunkSize);
                if(bytesRead == 0)
                    break;

                writeStream.Write(buffer, 0, bytesRead);
            }
            while(true);

            writeStream.Close();
            inputStream.Dispose();

            return System.Drawing.Image.FromFile(filePath);
        }

    }
}
