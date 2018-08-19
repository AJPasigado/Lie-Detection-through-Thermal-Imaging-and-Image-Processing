using System;
using System.Drawing;
using System.Windows.Forms;

/*
    EMGU CV Imports 
*/

using Emgu.CV;                  
using Emgu.CV.CvEnum;         
using Emgu.CV.Structure;        

namespace Lie_Detection {
    public partial class Main : Form {

        // Global Variables //

        bool IN_SESSION = false;  //Check if there is a session in progress
        bool FROM_FILE = false; //Check if the session is done realtime or not
        private Shadow SHADOW = new Shadow(); //Adds a shadow effect on modals

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
                EB_StartSession(); //Starts the eye blink session
                IN_SESSION = true; //Announce that the session is in progress
            }
            else if (e.KeyCode.ToString() == "F10")
            {
                if (!FROM_FILE) EB_Answer(); //If the session is realtime, the user can specify when to answer
            }
            else if (e.KeyCode.ToString() == "F11")
            {
                EB_EndSession(); //End the eye blink session
                IN_SESSION = false; //Announce that the session is done
                LoadReport(); //Loads the Report Form

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
            CAM_CAPTURE.Dispose(); //Turn off the camera after session
            EB_FromFileBTN.Visible = true; //Enable loading from file

            EB_AverageEyeBlinkLBL.Text = "";
            TOTAL_BLINKS = 0;
            EB_RealtimeLogTXBX.AppendText("=== END SESSION ===" + Environment.NewLine);

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
                Environment.Exit(0);
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

    }
}
