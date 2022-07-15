using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode.Codec;
using System;
using BarcodeLib.BarcodeReader;
using System.Collections.Generic;

namespace CollegeLMS{
    public class Camera{
        #region webcamSetup
        private FilterInfoCollection CaptureDevice;//Device 0 - Laptop Webcam, 1 - USB Camera
        private VideoCaptureDevice VideoCapture;
        private PictureBox picBox;

        public Camera(PictureBox picture){
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//Get Active Video Devices
            int selected = CaptureDevice.Count-1;
            VideoCapture = new VideoCaptureDevice(CaptureDevice[selected].MonikerString);//Select the first Device
            picBox = picture;
            VideoCapture.NewFrame += new NewFrameEventHandler(Frame_Event);//Set the Event Handler
        }
        public Camera(){}
        private void Frame_Event(object sender, NewFrameEventArgs eventArgs){
            try{
                picBox.Image = (Bitmap)eventArgs.Frame.Clone();
            }catch(Exception ex){ }
        }

        public void startCamera(){//Start WebCam
            VideoCapture.Start();
        }
        

        public void stopCamera(){//Stop WebCam
            if(VideoCapture.IsRunning) 
                VideoCapture.Stop();
        }

        public void CaptureImage(){//Take Pic From Camera
            stopCamera();
            picBox.Image.Save("cameraImage.jpeg", ImageFormat.Jpeg);
        }
        #endregion

        #region QRCode
        public Image generateQR(System.String data){
            QRCodeEncoder qrEncoder = new QRCodeEncoder();
            Bitmap qrcode = qrEncoder.Encode(data);
            return qrcode as Image;
        }
        public String decodeQR(){
            String code = "";
            try{
                OptimizeSetting setting = new OptimizeSetting();

                setting.setMaxOneBarcodePerPage(true);

                ScanArea top20 = new ScanArea(new PointF(0.0F, 0.0F), new PointF(100.0F, 20.0F));

                ScanArea bottom20 = new ScanArea(new PointF(0.0F, 80.0F), new PointF(100.0F, 100.0F));

                List<ScanArea> areas = new List<ScanArea>();
                areas.Add(top20);
                areas.Add(bottom20);

                setting.setAreas(areas);

                code = BarcodeReader.read(picBox.Image as Bitmap, BarcodeReader.QRCODE)[0];
            }catch(Exception e){}
            return code;
        }
        #endregion
    }
}
