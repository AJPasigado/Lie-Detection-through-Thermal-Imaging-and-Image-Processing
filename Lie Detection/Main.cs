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
        
        CascadeClassifier FACE_CASCADE = new CascadeClassifier(@"D:\Docs\GitHub\opencv\data\haarcascades\haarcascade_frontalface_default.xml");
        CascadeClassifier EYE_CASCADE = new CascadeClassifier(@"D:\Docs\GitHub\opencv\data\haarcascades\haarcascade_eye.xml");
        int TOTAL_BLINKS = 0;
        bool DETECT_EYES = false;
        VideoCapture CAM_CAPTURE;


        public Main() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {
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
            Application.Idle += processFrameAndUpdateGUI;
        }

        void processFrameAndUpdateGUI(object sender, EventArgs arg) {
            Image<Bgr, Byte> videoFeed = CAM_CAPTURE.QueryFrame().ToImage<Bgr, Byte>();

            Image<Gray, Byte> videoFeedGray = videoFeed.Convert<Gray, Byte>();
            Rectangle[] facesDetected = FACE_CASCADE.DetectMultiScale(videoFeedGray, 1.3, 5);

            try {
                videoFeed.Draw(facesDetected[0], new Bgr(Color.Blue), 2);
                //videoFeedGray.ROI = facesDetected[0];

                Rectangle[] eyesDetected = EYE_CASCADE.DetectMultiScale(videoFeedGray, 1.3, 5);
                try {
                    videoFeed.Draw(eyesDetected[0], new Bgr(Color.Blue), 2);
                    DETECT_EYES = true;
                    EB_BlinkedLBL.Hide();
                }
                catch (Exception) {
                    if (DETECT_EYES) {
                        TOTAL_BLINKS++;
                        EB_RealtimeLogTXBX.AppendText(DateTime.Now.ToString("HH:mm.ss") + "\n");
                        EB_BlinkedLBL.Show();
                    }
                    DETECT_EYES = false;
                }
                EB_VideoFeedIB.Image = videoFeed.Resize(EB_VideoFeedIB.Width, EB_VideoFeedIB.Height, Inter.Linear);
            }
            catch (Exception) { }

        
        }
    }
}
