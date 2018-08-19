using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lie_Detection {
    public partial class Report : Form {
        public string EB_data;
        int mode = 0;

        NaiveBayes nb = new NaiveBayes();

        #region Form Properties and Methods
        public Main reference = new Main();
        Point lastLocation;
        bool mouseDown;

        public Report() {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            LoadEyeBlinkData();
            currentLabel = TI_MainLBL;
            currentPanel = TI_MainPNL;
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

        private void Report_FormClosing(object sender, FormClosingEventArgs e) {
            reference.Location = Location;
            reference.Size = Size;
            reference.Show();
        }

        private void Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F9")
            {
                Close();
            }
        }

        #endregion

        #region Panel Properties

        Label currentLabel;
        Panel currentPanel;

        private void ChangePanel (Label newL, Panel newP, int newMode)
        {
            mode = newMode;
            currentLabel.ForeColor = Color.Silver;
            newL.ForeColor = Color.FromArgb(112, 112, 112);
            currentPanel.Hide();
            newP.Show();
            currentPanel = newP;
            currentLabel = newL;
        }

        private void EB_MainLBL_MouseEnter(object sender, EventArgs e) {
            EB_MainLBL.ForeColor = Color.FromArgb(112, 112, 112);
        }

        private void EB_MainLBL_MouseLeave(object sender, EventArgs e) {
            if (mode == 0) EB_MainLBL.ForeColor = Color.Silver;
        }

        private void EB_MainLBL_MouseClick(object sender, MouseEventArgs e) {
            ChangePanel(EB_MainLBL, EB_MainPNL, 1);
        }

        private void TI_MainLBL_MouseEnter(object sender, EventArgs e) {
            TI_MainLBL.ForeColor = Color.FromArgb(112, 112, 112);
        }

        private void TI_MainLBL_MouseLeave(object sender, EventArgs e) {
            if (mode == 1) TI_MainLBL.ForeColor = Color.Silver;
        }

        private void TI_MainLBL_MouseClick(object sender, MouseEventArgs e) {
            ChangePanel(TI_MainLBL, TI_MainPNL, 0);
        }

        private void EBTI_MainLBL_MouseEnter(object sender, EventArgs e)
        {
            EBTI_MainLBL.ForeColor = Color.FromArgb(112, 112, 112);
        }

        private void EBTI_MainLBL_MouseLeave(object sender, EventArgs e)
        {
            if (mode == 2) TI_MainLBL.ForeColor = Color.Silver;
        }

        private void EBTI_MainLBL_MouseClick(object sender, MouseEventArgs e)
        {
            ChangePanel(EBTI_MainLBL, EBTI_MainPNL, 2);
        }

        #endregion

        #region Eye Blink Properties
        List<double> finalAverageList = new List<double>();
        List<double> finalAfterList = new List<double>();

        private void LoadEyeBlinkData()
        {
            String a = EB_data;

            List<double> tempList = new List<double>(); //to store temporarily the number of eye blinks
            List<double> normalAverage = new List<double>();
            List<double> afterQuestionAverage = new List<double>();

            bool initial = false; //Flag if it is the start of the 

            int flag = 0; //Indicates if asking or answering
            int temp = 0;
            int blinks = 0;

            using (StringReader reader = new StringReader(a))
            {
                //Start reading the lines
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Equals("=== WATCHING/ASKING ==="))
                    {
                        //If the next line line is the start of asking
                        if (tempList.Count > 0)
                        {
                            //and if the list still has stored values (maybe from answering)

                            //Get the peak number of blinks after asking and store it in the final list
                            if (tempList.Count > 1) finalAfterList.Add(tempList.Max());
                            else finalAfterList.Add(0);
                            //and clear the temporary list
                            tempList.Clear();
                        }
                        initial = true; //Set the flag as initial value in the next sequence
                        blinks = 0; //Reset the blinks counter
                        flag = 1; //Indicate that this is asking mode
                    }
                    else if (line.Equals("=== ANSWERING ==="))
                    {
                        //If the next line indicates answering
                        if (tempList.Count > 0)
                        {
                            //and if there are stored values in the temporary list

                            //get the average for the number of blinks while asking and store it in the final list
                            finalAverageList.Add(tempList.Sum() / tempList.Count);
                            //and clear the temporary list
                            tempList.Clear();
                        }
                        initial = true; //Set the flag as initial value in the next sequence
                        blinks = 0; //Reset the blinks counter
                        flag = 2; //Indicate that this is answering mode
                    }
                    else if (line.Equals("=== END SESSION ==="))
                    {
                        //Now end the loop
                        break;
                    }
                    else
                    {
                        if (initial)
                        {
                            //If it is the initial value, store the time (in seconds) in a temporary value
                            //This is used to indicate which time to base the checker
                            temp = Convert.ToInt32(line.Split('.')[1]); initial = false;
                        }


                        if (Convert.ToInt32(line.Split('.')[1]) < temp + 4)
                        {
                            //This is where the inital value is used
                            //Compare the initial value with the current time and if it is not above four seconds, increment the blink counter
                            blinks++;
                        }
                        else
                        {
                            //If it is above four seconds,

                            //Add a data point in the graph to represent the time (X)
                            //dataPoint stores which column the data will be stored (like an index)
                            int dataPoint = EB_Q1CHRT.Series["Blinks"].Points.AddXY(line.Split('.')[0] + '.' + (temp + 4).ToString(), blinks);

                            if (flag == 2)
                            {
                                //If it is on answering mode, color the graph as red
                                EB_Q1CHRT.Series["Blinks"].Points[dataPoint].Color = Color.FromArgb(151, 128, 128);
                                //store the number of blinks in a temporary variable that holds all after-question eye blinks
                                afterQuestionAverage.Add(blinks);
                                //store the number of eye blinks in a temporary variable
                                tempList.Add(blinks);
                            }
                            else
                            {
                                //If it is on asking mode,

                                //store the number of blinks in a temporary variable that holds all asking eye blinks
                                normalAverage.Add(blinks);
                                //store the number of eye blinks in a temporary variable
                                tempList.Add(blinks);
                            }

                            //Reset the number of blinks after storing the values
                            blinks = 0;
                            //Get the number of eye blinks for the next four seconds
                            temp += 4;
                        }
                    }
                } //End of While-loop
            } //End of String Reader

            //Store the final blink data since it got out of the loop
            if (tempList.Count > 1) finalAfterList.Add(tempList.Max());
            tempList.Clear();

            EB_AfterQuestionAveLBL.Text = (finalAfterList.Sum() / finalAfterList.Count).ToString("F2");
            EB_NormalAverageLBL.Text = (finalAverageList.Sum() / finalAverageList.Count).ToString("F2");

            nb.EB_GenerateModel(); //Generate the Eye Blink model for NaiveBayes

            for (int i = 0; i < finalAverageList.Count; i++)
            {
                //Display the result in the data grid
                EB_ResultDTGRD.Rows.Add(i + 1, finalAverageList[i], finalAfterList[i], finalAfterList[i] / finalAverageList[i],
                        nb.EB_Predict(finalAfterList[i] / finalAverageList[i]) ? "Lie" : "Truth");
            }
        }

        #endregion

    }
}
