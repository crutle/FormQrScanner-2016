using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Common;
using System.Diagnostics;

namespace FormQrScanner
{
    public partial class FormQrScanner : Form
    {

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private Bitmap capturedImage;
        private String message = "";
        private string sub = "";
        private int eventId = 0;
        private int userId = 0;

        public FormQrScanner()
        {
            InitializeComponent();
        }
        private void FormQrScanner_Load(object sender, EventArgs e)
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo device in videoDevices)
                {
                    comboBoxCameraSource.Items.Add(device.Name);
                }
                comboBoxCameraSource.SelectedIndex = 0;

                videoSource = new VideoCaptureDevice();

                buttonStartStop.Text = "Start";
                buttonCapture.Enabled = false;
                buttonDecode.Enabled = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                textBoxMessage.Text = "An error has occurred attemping to load the webcam.";
            }
        }

        private void FormQRCodeScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxSource.Image = image;
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {

            try
            {
                if (videoSource.IsRunning)
                {
                    videoSource.Stop();
                    pictureBoxSource.Image = null;
                    pictureBoxCaptured.Image = null;
                    pictureBoxSource.Invalidate();
                    pictureBoxCaptured.Invalidate();

                    buttonStartStop.Text = "Start";
                    buttonCapture.Enabled = false;
                    buttonDecode.Enabled = false;
                }
                else
                {
                    videoSource = new VideoCaptureDevice(videoDevices[comboBoxCameraSource.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                    videoSource.Start();

                    timer1.Enabled = true;
                    buttonStartStop.Text = "Stop";
                    buttonCapture.Enabled = true;
                    buttonDecode.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                message = textBoxMessage.Text;
            }


        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                pictureBoxCaptured.Image = (Bitmap)pictureBoxSource.Image.Clone();
                capturedImage = (Bitmap)pictureBoxCaptured.Image;
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            textBoxMessage.Clear();

            if (capturedImage != null)
            {
                ExtractQRCodeMessageFromImage(capturedImage);
                textBoxMessage.Text = sub;
                textBoxMessage.ReadOnly = true;
                
                try
                {
                    eventId = Convert.ToInt32(eventIdText.Text);
                    userId = Convert.ToInt32(sub);
                    bool attendance = Db.attendance(eventId, userId);
                    if (attendance)
                        textBoxMessage.Text = "Attendance successfully taken!";
                    else
                        textBoxMessage.Text = "Attendance taking unsuccessful. Please try again.";
                } catch (Exception ex)
                {
                    //textBoxMessage.Text = ex.ToString();
                    textBoxMessage.Text = "Attendance taking unsuccessful. Please try again.";
                }
            }
        }

        private string ExtractQRCodeMessageFromImage(Bitmap bitmap)
        {
            try
            {
                BarcodeReader reader = new BarcodeReader
                    (null, newbitmap => new BitmapLuminanceSource(bitmap), luminance => new GlobalHistogramBinarizer(luminance));

                reader.AutoRotate = true;
                reader.TryInverted = true;
                reader.Options = new DecodingOptions { TryHarder = true };

                var result = reader.Decode(bitmap);

                if (result != null)
                {
                    message = result.Text;
                    int startPos = message.LastIndexOf("NOTE") + "NOTE".Length + 1;
                    int length = message.IndexOf("END:VCARD") - startPos;
                    sub = message.Substring(startPos, length);
                    //return message;
                    return sub;
                }
                else
                {
                    //message = "QRCode couldn't be decoded.";
                    sub = "QRCode couldn't be decoded. Please try again.";
                    return sub;
                }
            }
            catch (Exception ex)
            {
                //message = "QRCode couldn't be detected.";
                sub = "QRCode couldn't be decoded. Please try again.";
                return sub;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //BarcodeReader reader = new BarcodeReader();
            //Result result = reader.Decode((Bitmap)pictureBoxSource.Image);
            //try
            //{
            //    string decoded = result.ToString().Trim();
            //    if (decoded != "")
            //    {
            //        timer1.Stop();
            //        textBoxMessage.Text = decoded;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}

        }
    }
}
