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
            if (mode == 2) EBTI_MainLBL.ForeColor = Color.Silver;
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

            bool initial = false; //Flag if it is the start of the sequence

            int flag = 0; //Indicates if asking or answering
            TimeSpan currentTime = new TimeSpan(0,0,0);
            int blinks = 0;
            
            using (StringReader reader = new StringReader(a))
            {
                //Start reading the lines
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    if (line.Equals("=== WATCHING/ASKING ==="))
                    {
                        if (blinks != 0)
                        {
                            EB_AddToGraph(currentTime.ToString(), blinks);
                            tempList.Add(blinks);
                            finalAfterList.Add(tempList.Max());
                            tempList.Clear();
                        }

                        initial = true;
                        blinks = 0;
                        flag = 1;
                    }
                    else if (line.Equals("=== ANSWERING ==="))
                    {
                        if (blinks != 0)
                        {
                            EB_AddToGraph(currentTime.ToString(), blinks);
                            tempList.Add(blinks);
                            finalAverageList.Add(tempList.Sum() / tempList.Count);
                            tempList.Clear();
                        }

                        initial = true;
                        blinks = 0;
                        flag = 2;
                    }
                    else if (line.Equals("=== END SESSION ==="))
                    {
                        if (blinks != 0)
                        {
                            EB_Q1CHRT.Series["Blinks"].Points[EB_AddToGraph(currentTime.ToString(), blinks)].Color = Color.FromArgb(151, 128, 128);
                            tempList.Add(blinks);
                            finalAfterList.Add(tempList.Max());
                            tempList.Clear();
                        }

                        break;
                    }
                    else
                    {
                        if (initial)
                        {
                            //If it is the initial value, store the time (in seconds) in a temporary value
                            //This is used to indicate which time to base the checker
                            currentTime = new TimeSpan(
                                Convert.ToInt32(line.Split('.')[0].Split(':')[0]), 
                                Convert.ToInt32(line.Split('.')[0].Split(':')[1]),
                                Convert.ToInt32(line.Split('.')[1])
                                ); 
                            initial = false;
                        }

                        if (new TimeSpan(
                                Convert.ToInt32(line.Split('.')[0].Split(':')[0]),
                                Convert.ToInt32(line.Split('.')[0].Split(':')[1]),
                                Convert.ToInt32(line.Split('.')[1])
                                ) <= currentTime)
                        {
                            //This is where the inital value is used
                            //Compare the initial value with the current time and if it is not above four seconds, increment the blink counter
                            blinks++;
                        }
                        else
                        {


                            int dataPoint = EB_AddToGraph(currentTime.ToString(), blinks);
                            tempList.Add(blinks);

                            if (flag == 2)
                            {
                                //If it is on answering mode, color the graph as red
                                EB_Q1CHRT.Series["Blinks"].Points[dataPoint].Color = Color.FromArgb(151, 128, 128);
                            }

                            currentTime = new TimeSpan(
                                Convert.ToInt32(line.Split('.')[0].Split(':')[0]),
                                Convert.ToInt32(line.Split('.')[0].Split(':')[1]),
                                Convert.ToInt32(line.Split('.')[1]) + 4
                                );
                            blinks = 1;
                        }
                    }


                } //End of While-loop
            } //End of String Reader

            EB_QuestionsCountLBL.Text = finalAverageList.Count.ToString();
            EB_ModelAccuracyLBL.Text = (nb.EB_GenerateModel() * 100).ToString("#.00"); //Generate the Eye Blink model for NaiveBayes

            for (int i = 0; i < finalAverageList.Count; i++)
            {
                //Display the result in the data grid
                EB_ResultDTGRD.Rows.Add(i + 1, finalAverageList[i].ToString("#.00"), finalAfterList[i].ToString("#.00"), (finalAfterList[i] / finalAverageList[i]).ToString("#.00"),
                        nb.EB_Predict(finalAfterList[i] / finalAverageList[i]) ? "Lie" : "Truth");
            }
        }

        private int EB_AddToGraph(string x, int y)
        {
            return EB_Q1CHRT.Series["Blinks"].Points.AddXY(x, y);
        }

        #endregion

    }
}
