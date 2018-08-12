using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    EMGU CV Imports 
*/
using Emgu.CV;                  
using Emgu.CV.CvEnum;         
using Emgu.CV.Structure;        
using Emgu.CV.UI;               

namespace Lie_Detection {
    public partial class Main : Form {

        // member variables ///////////////////////////////////////////////////////////////////////
        
        CascadeClassifier FACE_CASCADE = new CascadeClassifier(@"D:\Documents\GitHub\opencv\data\haarcascades\haarcascade_frontalface_default.xml");
        CascadeClassifier EYE_CASCADE = new CascadeClassifier(@"D:\Documents\GitHub\opencv\data\haarcascades\haarcascade_eye.xml");
        int TOTAL_BLINKS = 0;
        bool DETECT_EYES = false;
        VideoCapture CAM_CAPTURE;

        bool START_SESSION = false;

        Point lastLocation;
        bool mouseDown;


        public Main() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {
         
        }

        void EyeBlinkProcess(object sender, EventArgs arg) {
            Image<Bgr, Byte> videoFeed = CAM_CAPTURE.QueryFrame().ToImage<Bgr, Byte>();

            Image<Gray, Byte> videoFeedGray = videoFeed.Convert<Gray, Byte>();
            Rectangle[] facesDetected = FACE_CASCADE.DetectMultiScale(videoFeedGray, 1.3, 5);
          
            if (!(facesDetected.Length == 0)) {
                videoFeed.Draw(facesDetected[0], new Bgr(Color.Blue), 2);

                Rectangle[] eyesDetected = EYE_CASCADE.DetectMultiScale(videoFeedGray, 1.3, 5);
                if (!(eyesDetected.Length==0)) {
                    videoFeed.Draw(eyesDetected[0], new Bgr(Color.Blue), 2);
                    if (START_SESSION) {
                        DETECT_EYES = true;
                        EB_BlinkedLBL.Hide();
                    }
                }
                else  {
                    if (DETECT_EYES && START_SESSION) {
                        TOTAL_BLINKS++;
                        EB_AverageEyeBlinkLBL.Text = TOTAL_BLINKS.ToString();
                        EB_RealtimeLogTXBX.AppendText(DateTime.Now.ToString("HH:mm.ss") + "\n");
                        EB_BlinkedLBL.Show();
                    }
                    DETECT_EYES = false;
                }
                EB_VideoFeedIB.Image = videoFeed.Resize(EB_VideoFeedIB.Width, EB_VideoFeedIB.Height, Inter.Linear);
                imageBox1.Image = videoFeed.Resize(EB_VideoFeedIB.Width, EB_VideoFeedIB.Height, Inter.Linear);
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode.ToString() == "F9") {
                if (!START_SESSION) {
                    StartCamera();
                    EB_RealtimeLogTXBX.Text = "";
                }
                EB_RealtimeLogTXBX.AppendText("=== WATCHING/ASKING ===\n");
                EB_AverageEyeBlinkLBL.Text = "0";
                TOTAL_BLINKS = 0;
                START_SESSION = true;
            } else if (e.KeyCode.ToString() == "F10") {
                EB_AverageEyeBlinkLBL.Text = "0";
                TOTAL_BLINKS = 0;
                EB_RealtimeLogTXBX.AppendText("=== ANSWERING ===\n");
            } else if (e.KeyCode.ToString() == "F11") {
                EndSession();
                Report report = new Report {
                    reference = this,
                    Location = Location,
                    Size = Size,
                    data = EB_RealtimeLogTXBX.Text
                };
                this.Hide();
                report.Show();
            } else if (e.KeyCode.ToString() == "F12") {
                EndSession();
            } else if (e.KeyCode.ToString() == "F3") {
                Close();
            }
        }

        private void EndSession()
        {
            Application.Idle -= EyeBlinkProcess;
            START_SESSION = false;
            EB_AverageEyeBlinkLBL.Text = "";
            TOTAL_BLINKS = 0;
            EB_RealtimeLogTXBX.AppendText("=== END SESSION ===\n");
        }

        private void StartCamera() {
            try {
                CAM_CAPTURE = new VideoCapture(0);
            }
            catch (Exception ex) {
                MessageBox.Show("unable to read from webcam, error: " + Environment.NewLine + Environment.NewLine +
                                ex.Message + Environment.NewLine + Environment.NewLine +
                                "exiting program");
                Environment.Exit(0);
                return;
            }
            Application.Idle += EyeBlinkProcess;
        }

        private void Drag_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
        }
        private void Drag_MouseDown(object sender, MouseEventArgs e) {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Drag_MouseMove(object sender, MouseEventArgs e) {
            if (mouseDown) {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
    }
}
