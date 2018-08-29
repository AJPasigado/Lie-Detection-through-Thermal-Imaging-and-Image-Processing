using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

/*
    EMGU CV Imports 
*/

using Emgu.CV;                  
using Emgu.CV.CvEnum;         
using Emgu.CV.Structure;

/*
    Thermal Image Imports
*/

using winusbdotnet.UsbDevices;
using AForge.Imaging.Filters;
using System.IO;
using System.Linq;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Lie_Detection {
    public partial class Main : Form {

        // Global Variables //

        bool IN_SESSION = false;  //Check if there is a session in progress
        bool FROM_FILE = false; //Check if the session is done realtime or not
        private Shadow SHADOW = new Shadow(); //Adds a shadow effect on modals

        SeekThermal thermal;
        Thread thermalThread;

        #region Form Properties

        Point FORM_LAST_LOCATION;  //Checks the last location of the form while dragging
        bool FORM_MOUSE_DOWN; //Checks if the user drags the mouse

        public Main() {
            InitializeComponent();
        }

        private void Drag_MouseUp(object sender, MouseEventArgs e)
        {
            FORM_MOUSE_DOWN = false;
        }

        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            FORM_MOUSE_DOWN = true;
            FORM_LAST_LOCATION = e.Location;
        }
        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (FORM_MOUSE_DOWN)
            {
                Location = new Point((Location.X - FORM_LAST_LOCATION.X) + e.X, (Location.Y - FORM_LAST_LOCATION.Y) + e.Y);
                Update();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Adjust the properties of the shadow for modals
            SHADOW.Size = Size;
            SHADOW.Location = Location;
            SHADOW.Transparency = 0.6;

            //Adds a fade-in effect on startup
            FadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            //The method for the fade-in effect
            Opacity += 0.2;
            if (Opacity == 1) FadeTimer.Stop();
        }

        private void Main_LocationChanged(object sender, EventArgs e)
        {
            //Adjust the location of the modal shadow when the form is moved
            SHADOW.Location = Location;
        }

        #endregion

        #region Common Processing

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            // The methods for the pressing keys on the forms

            if (e.KeyCode.ToString() == "F8")
            {
                if (!IN_SESSION)
                {
                    //If the session is done, provide the user an opportunity to modify the data
                    EB_FileProcessData();
                }
            }
            else if (e.KeyCode.ToString() == "F9")
            {
                TI_StartSession();
                EB_StartSession(); //Starts the eye blink session
                IN_SESSION = true; //Announce that the session is in progress
            }
            else if (e.KeyCode.ToString() == "F10")
            {
                if (!FROM_FILE) EB_Answer(); //If the session is realtime, the user can specify when to answer
            }
            else if (e.KeyCode.ToString() == "F11")
            {
                if (EB_RealtimeLogTXBX.Text != String.Empty) {
                    EB_EndSession(); //End the eye blink session
                    IN_SESSION = false; //Announce that the session is done
                    LoadReport(); //Loads the Report Form
                } else
                {
                    MessageBox.Show("Please start a session first before generating a report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (e.KeyCode.ToString() == "F12")
            {
                EB_EndSession(); //End the eye blink session
                IN_SESSION = false; //Announce that the session is done
            }
            else if (e.KeyCode.ToString() == "F1")
            {
                var form = new Help
                {
                    refer = SHADOW
                };

                SHADOW.Transparent();
                SHADOW.Form = form;
                SHADOW.ShowDialog();
            }
            else if (e.KeyCode.ToString() == "F2")
            {
                var form = new About
                {
                    refer = SHADOW
                };

                SHADOW.Transparent();
                SHADOW.Form = form;
                SHADOW.ShowDialog();
            }
            else if (e.KeyCode.ToString() == "F3")
            {
                Close();
            }
        }

        private void LoadReport()
        {
            EB_RealtimeLogTXBX.AppendText("=== END SESSION ===" + Environment.NewLine);
            Report report = new Report
            {
                reference = this,
                Location = Location,
                Size = Size,
                EB_data = EB_RealtimeLogTXBX.Text //Pass the eye blink data from the log
            };
            Hide();
            report.Show();
        }

        #endregion

        #region Eye Blink Processing Realtime

        // Global Variables for Eye Blink Processing in Realtime //

        CascadeClassifier FACE_CASCADE = new CascadeClassifier(@"D:\Documents\GitHub\opencv\data\haarcascades\haarcascade_frontalface_default.xml");
        CascadeClassifier EYE_CASCADE = new CascadeClassifier(@"D:\Documents\GitHub\opencv\data\haarcascades\haarcascade_eye.xml");
        int TOTAL_BLINKS = 0;
        bool DETECT_EYES = false;
        VideoCapture CAM_CAPTURE;
        DateTime START_TIME;

        private void EB_StartSession()
        {
            if (!IN_SESSION && !FROM_FILE)
            {
                //If it is a new session and realtime, turn on the camera and clear the log
                EB_StartCamera();
                EB_RealtimeLogTXBX.Text = "";
            } else if (FROM_FILE) {

                //If it is not realtime, then just clear the log
                EB_RealtimeLogTXBX.Text = "";
            }

            EB_FromFileBTN.Visible = false; //Disable loading from new files when session is in progress
            START_TIME = DateTime.Now;
            EB_RealtimeLogTXBX.AppendText("=== WATCHING/ASKING ===" + Environment.NewLine); //Indicates the first or the next question
            EB_AverageEyeBlinkLBL.Text = "0"; //Reset the total eye blinks
            TOTAL_BLINKS = 0;
        }

        private void EB_Answer()
        {
            EB_AverageEyeBlinkLBL.Text = "0";
            TOTAL_BLINKS = 0;
            EB_RealtimeLogTXBX.AppendText("=== ANSWERING ===" + Environment.NewLine);
        }

        private void EB_EndSession()
        {
            if (CAM_CAPTURE != null) CAM_CAPTURE.Dispose(); //Turn off the camera after session
            EB_FromFileBTN.Visible = true; //Enable loading from file

            EB_AverageEyeBlinkLBL.Text = "";
            TOTAL_BLINKS = 0;

            if (!FROM_FILE) Application.Idle -= EB_GetFrameProcess; //If realtime, removes the method that process live data
            else
            {
                //If not realtime, stop the timer that process the frames and call the form to post-process the data
                EB_FramesTimer.Stop();
                EB_FileProcessData();
                FROM_FILE = false; //Announce that loading from file is finished
            }
        }

        private void EB_StartCamera()
        {
            try
            {
                CAM_CAPTURE = new VideoCapture(0); //Starts the camers
            }
            catch (Exception ex)
            {
                MessageBox.Show("unable to read from webcam, error: " + Environment.NewLine + Environment.NewLine +
                                ex.Message + Environment.NewLine + Environment.NewLine +
                                "exiting program");
                return;
            }
            Application.Idle += EB_GetFrameProcess; //Adds the method that processes live data
        }

        void EB_GetFrameProcess(object sender, EventArgs arg) {
            //Gets the current frame from the camera and passes it to  EB_ProcessFrame to process
            Image<Bgr, Byte> videoFeed = CAM_CAPTURE.QueryFrame().ToImage<Bgr, Byte>();
            EB_ProcessFrame(videoFeed);
        }

        void EB_ProcessFrame(Image<Bgr, Byte> videoFeed)
        {
            Image<Gray, Byte> videoFeedGray = videoFeed.Convert<Gray, Byte>(); //Convert the frame to grayscale to better see features
            Rectangle[] facesDetected = FACE_CASCADE.DetectMultiScale(videoFeedGray, 1.3, 5); //Detect Facial Features and find the location

            if (!(facesDetected.Length == 0))
            {
                //If a face is detected
                videoFeed.Draw(facesDetected[0], new Bgr(Color.Blue), 2); //Draw the rectangle on the frame to indicated the detected face
                facesDetected[0].Height /= 2; //Divide the area of the face to half to process only the eye part
                facesDetected[0].Height += 30; //Adjust to center the eyes
                videoFeedGray.ROI = facesDetected[0]; //Focus only the eyes

                Rectangle[] eyesDetected = EYE_CASCADE.DetectMultiScale(videoFeedGray, 1.3, 5); //Detect the eyes features from the adjusted video

                if (!(eyesDetected.Length == 0))
                {
                    //If an eye is detected
                    eyesDetected[0].X += facesDetected[0].X;
                    eyesDetected[0].Y += facesDetected[0].Y;
                    videoFeed.Draw(eyesDetected[0], new Bgr(Color.Blue), 2); //Draw the rectangle for the eyes

                    DETECT_EYES = true; //Announce that an eye is detected
                    EB_BlinkedLBL.Hide(); //Hide the "Blinked" indicator
                }
                else
                {
                    //If an eye is not detected
                    if (DETECT_EYES)
                    {
                        //But eyes were detected from the previous frame, then the person blinked
                        TOTAL_BLINKS++; //Increment the eye blink counter
                        EB_AverageEyeBlinkLBL.Text = TOTAL_BLINKS.ToString(); //Update the total eye blinks label
                        TimeSpan temp = DateTime.Now - START_TIME;
                        EB_RealtimeLogTXBX.AppendText($"{temp.Hours:D2}:{temp.Minutes:D2}.{temp.Seconds:D2} {Environment.NewLine}"); //Add the time to the log
                        EB_BlinkedLBL.Show(); //Show the "Blinked" label
                    }
                    DETECT_EYES = false; //Reset the flag for eyes detected
                }
            }
            EB_VideoFeedIB.Image = videoFeed.Resize(EB_VideoFeedIB.Width, EB_VideoFeedIB.Height, Inter.Linear); //Update the frame in the UI
        }

        #endregion

        #region Eye Blink Processing From File

        public String EB_PROCESSED_DATA = ""; //A placeholder for the processed data to be passed

        private void EB_FromFileBTN_Click(object sender, EventArgs e)
        {
            if (EB_OpenFileDBOX.ShowDialog() == DialogResult.OK)
            {
                //Open a dailog box to search for a video file
                CAM_CAPTURE = new VideoCapture(EB_OpenFileDBOX.FileName); //Store the video file in the captured frames
                IN_SESSION = true; //Start the session
                FROM_FILE = true; //Indicate that the app is loading from a file
                EB_StartSession(); 
                EB_FramesTimer.Start(); //The timer that process the frames
            }
        }

        private void EB_FramesTimer_Tick(object sender, EventArgs e)
        {
            Mat m = new Mat();
            CAM_CAPTURE.Read(m); //Read the frame and store it in a mat

            using (Image<Bgr, Byte> frame = m.ToImage<Bgr, Byte>())
            {
                //Using 'using' to enable automatic garbage collection
                try
                {
                    EB_ProcessFrame(frame.Copy()); //Pass the frame to the Frame Processor
                }
                catch
                {
                    EB_EndSession(); //If no more frames are detected, stop the session
                }
            }
        }

        private void EB_FileProcessData()
        {
            EB_PROCESSED_DATA = EB_RealtimeLogTXBX.Text; //Store the current log

            var form = new FromFileProcessingFORM {
                reference = this,
                data = EB_RealtimeLogTXBX.Text, //Send the data to be processed
                refer = SHADOW
            };
            
            SHADOW.Transparent();
            SHADOW.Form = form;
            SHADOW.ShowDialog();
            EB_RealtimeLogTXBX.Text = EB_PROCESSED_DATA; //Replace the log with the processed data
        }

        #endregion

        private void TI_FromFileBTN_Click(object sender, EventArgs e) {
            if (EB_OpenFileDBOX.ShowDialog() == DialogResult.OK) {
                //Open a dailog box to search for a video file
                IN_SESSION = true; //Start the session
                FROM_FILE = true; //Indicate that the app is loading from a file
            }
        }

        ThermalFrame TI_currentFrame, TI_lastUsableFrame;

        bool TI_stopThread;
        bool TI_grabExternalReference = false;
        bool TI_firstAfterCal = false;
        bool TI_usignExternalCal = false;
        bool TI_autoSaveImg = false;
        bool TI_isRunning = true;

        string TI_localPath;
        //string tempUnit;
        public bool TI_progress = false;

        ushort[] TI_arrID4 = new ushort[32448];
        ushort[] TI_arrID1 = new ushort[32448];
        ushort[] TI_arrID3 = new ushort[32448];

        bool[] TI_badPixelArr = new bool[32448];

        ushort[] TI_gMode = new ushort[1000];

        ushort[,] TI_palleteArr = new ushort[1001, 3];//-> ushort

        byte[] TI_imgBuffer = new byte[97344];

        ushort TI_gModePeakIx = 0;
        ushort TI_gModePeakCnt = 0;
        ushort TI_gModeLeft = 0;
        ushort TI_gModeRight = 0;
        ushort TI_gModeLeftManual = 0;
        ushort TI_gModeRightManual = 0;
        ushort TI_avgID4 = 0;
        ushort TI_avgID1 = 0;
        ushort TI_maxTempRaw = 0;

        double[] TI_gainCalArr = new double[32448];

        Bitmap TI_bitmap = new Bitmap(208, 156, PixelFormat.Format24bppRgb);
        Bitmap TI_croppedBitmap = new Bitmap(206, 156, PixelFormat.Format24bppRgb);
        public Bitmap TI_bigBitmap = new Bitmap(412, 312, PixelFormat.Format24bppRgb);
        BitmapData TI_bitmap_data;

        ResizeBilinear bilinearResize = new ResizeBilinear(412, 312);
        Crop cropFilter = new Crop(new Rectangle(0, 0, 206, 156));

        private void TI_StartSession() {
            TI_localPath = Directory.GetCurrentDirectory().ToString();
            Directory.CreateDirectory(TI_localPath + @"\export");

            var device = SeekThermal.Enumerate().FirstOrDefault();
            if (device == null) {
                MessageBox.Show("No Seek Thermal devices found.");
                return;
            }
            thermal = new SeekThermal(device);

            thermalThread = new Thread(TI_ThreadProc);
            thermalThread.IsBackground = true;
            thermalThread.Start();
        }

        void TI_ThreadProc() {
            while (!TI_stopThread && thermal != null) {
                TI_progress = false;
                TI_currentFrame = thermal.GetFrameBlocking();
                
                switch (TI_currentFrame.StatusByte) {
                    case 4://gain calibration
                        TI_arrID4 = TI_currentFrame.RawDataU16;
                        TI_avgID4 = TI_GetMode(TI_arrID4);

                        for (int i = 0; i < 32448; i++) {
                            if (TI_arrID4[i] > 2000 && TI_arrID4[i] < 8000) {
                                TI_gainCalArr[i] = TI_avgID4 / (double)TI_arrID4[i];
                            } else {
                                TI_gainCalArr[i] = 1;
                                TI_badPixelArr[i] = true;
                            }
                        }
                        break;

                    case 1://shutter calibration
                        TI_markBadPixels();
                        if (!TI_usignExternalCal) {
                            TI_arrID1 = TI_currentFrame.RawDataU16;
                        }
                        TI_firstAfterCal = true;
                        break;

                    case 3://image frame
                        TI_markBadPixels();
                        if (TI_grabExternalReference)//use this image as reference
                        {
                            TI_grabExternalReference = false;
                            TI_usignExternalCal = true;
                            TI_arrID1 = TI_currentFrame.RawDataU16;
                        } else {
                            //MessageBox.Show("current frame status " + currentFrame);
                            TI_arrID3 = TI_currentFrame.RawDataU16;


                            for (int i = 0; i < 32448; i++) {
                                if (TI_arrID3[i] > 2000) {
                                    TI_arrID3[i] = (ushort)((TI_arrID3[i] - TI_arrID1[i]) * TI_gainCalArr[i] + 7500);
                                } else {
                                    TI_arrID3[i] = 0;
                                    TI_badPixelArr[i] = true;
                                }
                            }

                            TI_fixBadPixels();
                            TI_removeNoise();
                            TI_getHistogram();
                            TI_fillImgBuffer();
                            TI_lastUsableFrame = TI_currentFrame;
                            TI_progress = true;
                        }
                        break;

                    default:
                        break;
                }
                
                if (TI_progress) {
                    Invalidate();
                }
            }
        }
        private void TI_fillImgBuffer() {
            ushort v = 0;
            ushort loc = 0;

            double iScaler;
            iScaler = (double)(TI_gModeRight - TI_gModeLeft) / 1000;

            for (int i = 0; i < 32448; i++) {
                v = TI_arrID3[i];
                if (v < TI_gModeLeft) v = TI_gModeLeft;
                if (v > TI_gModeRight) v = TI_gModeRight;
                v = (ushort)(v - TI_gModeLeft);
                loc = (ushort)(v / iScaler);

                TI_imgBuffer[i * 3] = (byte)TI_palleteArr[loc, 2];
                TI_imgBuffer[i * 3 + 1] = (byte)TI_palleteArr[loc, 1];
                TI_imgBuffer[i * 3 + 2] = (byte)TI_palleteArr[loc, 0];
            }
        }

        private void TI_markBadPixels() {
            ushort[] RawDataArr = TI_currentFrame.RawDataU16;

            for (int i = 0; i < RawDataArr.Length; i++) {
                if (RawDataArr[i] < 2000 || RawDataArr[i] > 22000) {
                    TI_badPixelArr[i] = true;
                }
            }
        }

        private void TI_fixBadPixels() {
            ushort x = 0;
            ushort y = 0;
            ushort i = 0;
            ushort nr = 0;
            ushort val = 0;

            for (y = 0; y < 156; y++) {
                for (x = 0; x < 208; x++, i++) {
                    if (TI_badPixelArr[i] && x < 206) {

                        val = 0;
                        nr = 0;

                        if (y > 0 && !TI_badPixelArr[i - 208]) //top pixel
                        {
                            val += TI_arrID3[i - 208];
                            ++nr;
                        }

                        if (y < 155 && !TI_badPixelArr[i + 208]) // bottom pixel
                        {
                            val += TI_arrID3[i + 208];
                            ++nr;
                        }

                        if (x > 0 && !TI_badPixelArr[i - 1]) //Left pixel
                        {
                            val += TI_arrID3[i - 1];
                            ++nr;
                        }

                        if (x < 205 && !TI_badPixelArr[i + 1]) //Right pixel
                        {
                            val += TI_arrID3[i + 1];
                            ++nr;
                        }

                        if (nr > 0) {
                            val /= nr;
                            TI_arrID3[i] = val;
                        }
                    }
                }
            }
        }

        private void TI_removeNoise() {
            ushort x = 0;
            ushort y = 0;
            ushort i = 0;
            ushort val = 0;
            ushort[] arrColor = new ushort[4];

            for (y = 0; y < 156; y++) {
                for (x = 0; x < 208; x++) {
                    if (x > 0 && x < 206 && y > 0 && y < 155) {
                        arrColor[0] = TI_arrID3[i - 208];//top
                        arrColor[1] = TI_arrID3[i + 208];//bottom
                        arrColor[2] = TI_arrID3[i - 1];//left
                        arrColor[3] = TI_arrID3[i + 1];//right

                        val = (ushort)((arrColor[0] + arrColor[1] + arrColor[2] + arrColor[3] - TI_Highest(arrColor) - TI_Lowest(arrColor)) / 2);

                        if (Math.Abs(val - TI_arrID3[i]) > 100 && val != 0) {
                            TI_arrID3[i] = val;
                        }
                    }
                    i++;
                }
            }

        }

        private ushort TI_Highest(ushort[] numbers) {
            ushort highest = 0;

            for (ushort i = 0; i < 4; i++) {
                if (numbers[i] > highest)
                    highest = numbers[i];
            }

            return highest;
        }

        private ushort TI_Lowest(ushort[] numbers) {
            ushort lowest = 30000;

            for (ushort i = 0; i < 4; i++) {
                if (numbers[i] < lowest)
                    lowest = numbers[i];
            }

            return lowest;
        }

        public void TI_cameraExit() {
            TI_stopThread = true;
            if (thermal != null) {
                thermalThread.Join(500);
                thermal.Deinit();
            }
        }

        public void TI_savePerFrame() {
            TI_autoSaveImg = !TI_autoSaveImg;
        }

        public ushort TI_GetMode(ushort[] arr) {
            ushort[] arrMode = new ushort[320];
            ushort topPos = 0;
            for (ushort i = 0; i < 32448; i++) {
                if ((arr[i] > 1000) && (arr[i] / 100 != 0)) arrMode[(arr[i]) / 100]++;
            }

            topPos = (ushort)Array.IndexOf(arrMode, arrMode.Max());

            return (ushort)(topPos * 100);
        }

        public void TI_getHistogram() {
            TI_maxTempRaw = TI_arrID3.Max();
            ushort[] arrMode = new ushort[2100];
            ushort topPos = 0;
            for (ushort i = 0; i < 32448; i++) {
                if ((TI_arrID3[i] > 1000) && (TI_arrID3[i] / 10 != 0) && !TI_badPixelArr[i]) arrMode[(TI_arrID3[i]) / 10]++;
            }

            topPos = (ushort)Array.IndexOf(arrMode, arrMode.Max());

            TI_gMode = arrMode;
            TI_gModePeakCnt = arrMode.Max();
            TI_gModePeakIx = (ushort)(topPos * 10);

            //lower it to 100px;
            for (ushort i = 0; i < 2100; i++) {
                TI_gMode[i] = (ushort)((double)arrMode[i] / TI_gModePeakCnt * 100);
            }

            TI_gModeLeft = TI_gModePeakIx;
            TI_gModeRight = TI_gModePeakIx;
            //find left border:
            for (ushort i = 0; i < topPos; i++) {
                if (arrMode[i] > arrMode[topPos] * 0.01) {
                    TI_gModeLeft = (ushort)(i * 10);
                    break;
                }
            }

            //find right border:
            for (ushort i = 2099; i > topPos; i--) {
                if (arrMode[i] > arrMode[topPos] * 0.01) {
                    TI_gModeRight = (ushort)(i * 10);
                    break;
                }
            }
            TI_gModeLeftManual = TI_gModeLeft;
            TI_gModeRightManual = TI_gModeRight;
        }

        public void TI_pauseFrame() {
            if (TI_isRunning) {
                thermalThread.Suspend();
                //start
            } else {
                thermalThread.Resume();
                //stop
            }
            TI_isRunning = !TI_isRunning;
        }

        private string TI_rawToTemp(int val) {
            double tempVal = 0;

            tempVal = (double)(val - 5950) / 40 + 273.15;
            tempVal = tempVal - 273.15;//C

            return tempVal.ToString("F1", CultureInfo.InvariantCulture);
        }

        public void TI_getFrames(object sender, PaintEventArgs e) {
            //MessageBox.Show(" " + lastUsableFrame);
            if (TI_lastUsableFrame != null) {
                string minTemp = TI_rawToTemp(TI_gModeLeft);
                string maxTemp = TI_rawToTemp(TI_gModeRight);

                /*lblMinTemp.Text = minTemp;
                lblMaxTemp.Text = maxTemp;

                lblLeft.Text = gModeLeft.ToString();
                lblRight.Text = gModeRight.ToString();
                label2.Text = maxTempRaw.ToString();*/

                TI_bitmap_data = TI_bitmap.LockBits(new Rectangle(0, 0, TI_bitmap.Width, TI_bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(TI_imgBuffer, 0, TI_bitmap_data.Scan0, TI_imgBuffer.Length);
                TI_bitmap.UnlockBits(TI_bitmap_data);

                //crop image to 206x156 line81 Crop cropFilter = new Crop(new Rectangle(0, 0, 206, 156));
                TI_croppedBitmap = cropFilter.Apply(TI_bitmap);

                //upscale 200 % line83 ResizeBilinear bilinearResize = new ResizeBilinear(412, 312);
                TI_bigBitmap = bilinearResize.Apply(TI_croppedBitmap);

                TI_VideoFeedIB.Image = new Image<Bgr, Byte>(TI_bigBitmap);
                //MessageBox.Show("test working " + bigBitmap);
                if (TI_autoSaveImg) TI_bigBitmap.Save(TI_localPath + @"\export\seek_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss_fff") + ".png");
            }
        }
    }
}
