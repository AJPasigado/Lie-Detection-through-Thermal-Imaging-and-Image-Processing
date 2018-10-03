using Lie_Detection.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lie_Detection {
    public partial class Report : Form {
        public string EB_data;
        public string TI_data;
        int mode = 0;
        string python = @"C:\Users\ajpas\AppData\Local\Programs\Python\Python37\python.exe";

        #region Form Properties and Methods
        public Main reference = new Main();
        Point lastLocation;
        bool mouseDown;

        public Report() {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
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
            } else if (e.KeyCode.ToString() == "F10") {
                ProcessData();
            }
        }

        private void Report_Shown(object sender, EventArgs e) {
            LoadThermalData();
            LoadEyeBlinkData();
            LoadCombinedData();
        }

        private void ProcessData() {
            string[,] pass = new string[EBTI_SummaryGRD.Rows.Count, 3];

            foreach (DataGridViewRow x in EBTI_SummaryGRD.Rows) {
                pass[x.Index, 0] = x.Cells[1].Value.ToString();
                pass[x.Index, 1] = x.Cells[2].Value.ToString();
                pass[x.Index, 2] = x.Cells[3].Value.ToString();
            }

            Shadow SHADOW = new Shadow();
            SHADOW.Size = Size;
            SHADOW.Location = Location;
            SHADOW.Transparency = 0.6;
            SHADOW.Location = this.Location;

            var form = new AddToModelForm {
                reference = this,
                refer = SHADOW,
                python = python,
                ebti_slope = pass
            };

            SHADOW.Transparent();
            SHADOW.Form = form;
            SHADOW.ShowDialog();

            
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
            if (mode != 1) EB_MainLBL.ForeColor = Color.Silver;
        }

        private void EB_MainLBL_MouseClick(object sender, MouseEventArgs e) {
            ChangePanel(EB_MainLBL, EB_MainPNL, 1);
        }

        private void TI_MainLBL_MouseEnter(object sender, EventArgs e) {
            TI_MainLBL.ForeColor = Color.FromArgb(112, 112, 112);
        }

        private void TI_MainLBL_MouseLeave(object sender, EventArgs e) {
            if (mode != 0) TI_MainLBL.ForeColor = Color.Silver;
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
            if (mode != 2) EBTI_MainLBL.ForeColor = Color.Silver;
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

            try {
                using (StringReader reader = new StringReader(a)) {
                    //Start reading the lines
                    string line;
                    while ((line = reader.ReadLine()) != null) {

                        if (line.Trim(' ').Equals("=== WATCHING/ASKING ===")) {
                            if (blinks != 0) {
                                EB_AddToGraph(currentTime.ToString(), blinks);
                                tempList.Add(blinks);
                                finalAfterList.Add(tempList.Max());
                                tempList.Clear();
                            }

                            initial = true;
                            blinks = 0;
                            flag = 1;
                        } else if (line.Trim(' ').Equals("=== ANSWERING ===")) {
                            if (blinks != 0) {
                                EB_AddToGraph(currentTime.ToString(), blinks);
                                tempList.Add(blinks);
                                finalAverageList.Add(tempList.Sum() / tempList.Count);
                                tempList.Clear();
                            }

                            initial = true;
                            blinks = 0;
                            flag = 2;
                        } else if (line.Trim(' ').Equals("=== END SESSION ===")) {
                            if (blinks != 0) {
                                EB_Q1CHRT.Series["Blinks"].Points[EB_AddToGraph(currentTime.ToString(), blinks)].Color = Color.FromArgb(151, 128, 128);
                                tempList.Add(blinks);
                                finalAfterList.Add(tempList.Max());
                                tempList.Clear();
                            }

                            break;
                        } else {
                            if (initial) {
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
                                    ) <= currentTime) {
                                //This is where the inital value is used
                                //Compare the initial value with the current time and if it is not above four seconds, increment the blink counter
                                blinks++;
                            } else {


                                int dataPoint = EB_AddToGraph(currentTime.ToString(), blinks);
                                tempList.Add(blinks);

                                if (flag == 2) {
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
            } catch (Exception e){
                MessageBox.Show(e.Message, "Could not process eye blink data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            EB_QuestionsCountLBL.Text = finalAverageList.Count.ToString();

            try {
                EB_slope = new double[finalAfterList.Count()];

                for (int i = 0; i < finalAfterList.Count(); i++) {
                    EB_slope[i] = finalAfterList[i] / finalAverageList[i];
                }

            } catch (Exception e) {
                MessageBox.Show(e.Message, "Could not finish Eye Blink prediction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        double[] EB_slope;

        private int EB_AddToGraph(string x, int y)
        {
            return EB_Q1CHRT.Series["Blinks"].Points.AddXY(x, y);
        }

        #endregion

        #region Thermal Imaging
        double[] TI_slope;
        List<double> tempList = new List<double>();

        private void LoadThermalData() {
            String a = TI_data;
            double total = 0;
            double count = 0;
            double maxTemp = 0;
            double minTemp = 50;

            double tempTotal = 0;
            double tempCount = 0;

            double questionCount = 0;
            bool initial = true;

            try {
                using (StringReader reader = new StringReader(a)) {
                    //Start reading the lines
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        if (line.Trim(' ').Equals("=== WATCHING/ASKING ===")) {
                            if (!initial) {
                                questionCount++;
                                TI_Q1CHRT.Series["Thermal"].Points.AddXY(questionCount, (tempTotal / tempCount).ToString("F3"));
                                tempList.Add(tempTotal / tempCount);
                                tempTotal = 0;
                                tempCount = 0;
                            }
                            initial = false;
                        } else if (line.Trim(' ').Equals("=== END SESSION ===")) {
                            questionCount++;
                            TI_Q1CHRT.Series["Thermal"].Points.AddXY(questionCount, (tempTotal/tempCount).ToString("F3"));
                            tempList.Add(tempTotal / tempCount);

                            break;
                        } else {
                            double temp = double.Parse(line.Trim(' ').Split(' ')[1]);
                            total += temp;
                            count++;

                            maxTemp = temp > maxTemp ? temp : maxTemp;
                            minTemp = temp < minTemp ? temp : minTemp;

                            tempTotal += temp;
                            tempCount++;
                        }
                            
                    }
                }
            } catch (Exception e){
                MessageBox.Show(e.Message, "Could not process thermal image data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TI_AverageTempLBL.Text = tempList.Average().ToString("F3");
            TI_NumberOfQuestionsLBL.Text = questionCount.ToString();
            TI_PeakTempLBL.Text = maxTemp.ToString("F3");

            TI_Q1CHRT.ChartAreas[0].AxisY.Minimum = minTemp - 0.5;
            TI_Q1CHRT.ChartAreas[0].AxisY.Maximum = maxTemp + 0.5;
            TI_Q1CHRT.ChartAreas[0].AxisX.Maximum = questionCount + 1;

            TI_slope = new double[tempList.Count()];

            for (int i = 0; i < tempList.Count(); i++) {
                TI_slope[i] = tempList[i] / tempList.Average();
            }

        }
        #endregion
        
        #region Combined Data
      
        public void LoadCombinedData() {
            if (TI_slope.Count() == EB_slope.Count()) {
                try {
                    string[] result = NaiveBayesPredict(EB_slope, TI_slope, EB_slope.Concat(TI_slope).ToArray()).Split('-');
                    string[] eb_result = result[0].Split(',');
                    string[] ti_result = result[1].Split(',');
                    string[] ebti_result = result[2].Split(',');

                    EB_ResultDTGRD.Rows.Clear();
                    for (int i = 0; i < finalAverageList.Count; i++) {
                    //Display the result in the data grid
                     EB_ResultDTGRD.Rows.Add(i + 1, finalAverageList[i].ToString("#.00"), finalAfterList[i].ToString("#.00"), (EB_slope[i]).ToString("#.00"),
                                bool.Parse(eb_result[i]) ? "Lie" : "Truth");
                    }

                    TI_SummaryDataGRD.Rows.Clear();
                    for (int i = 0; i < tempList.Count; i++) {
                    //Display the result in the data grid
                         TI_SummaryDataGRD.Rows.Add(i + 1, tempList[i].ToString("F3"), TI_slope[i].ToString("F3"), bool.Parse(ti_result[i]) ? "Lie" : "Truth");
                    }
                    
                    EBTI_Q1CHRT.ChartAreas[0].AxisX.Maximum = EB_slope.Count() + 1;

                    EBTI_Q1CHRT.Series["Thermal"].Points.Clear();
                    EBTI_Q1CHRT.Series["EyeBlink"].Points.Clear();
                    EBTI_SummaryGRD.Rows.Clear();
                    for (int i = 0; i < EB_slope.Count(); i++) {
                        EBTI_Q1CHRT.Series["Thermal"].Points.AddXY(i+1, TI_slope[i].ToString("F3"));
                        EBTI_Q1CHRT.Series["EyeBlink"].Points.AddXY(i+1, EB_slope[i].ToString("F3"));
                        //Display the result in the data grid
                        EBTI_SummaryGRD.Rows.Add(i + 1, TI_slope[i].ToString("F3"), EB_slope[i].ToString("F3"), bool.Parse(ebti_result[i]) ? "Lie" : "Truth");
                    }

                    try {
                        EB_ModelAccuracyLBL.Text = (double.Parse(Settings.Default.eb_slope) * 100).ToString() + "%"; //Generate the Eye Blink model for NaiveBayes
                        TI_ModelAccuracyLBL.Text = (double.Parse(Settings.Default.ti_slope) * 100).ToString() + "%";
                        EBTI_CombinedAccuracyLBL.Text = (double.Parse(Settings.Default.ebti_slope) * 100).ToString() + "%";
                        EBTI_EyeAccuracyLBL.Text = EB_ModelAccuracyLBL.Text;
                        EBTI_ThermalAccuracyLBL.Text = TI_ModelAccuracyLBL.Text;
                        EBTI_QuestionsLBL.Text = EB_QuestionsCountLBL.Text == TI_NumberOfQuestionsLBL.Text ? EB_QuestionsCountLBL.Text : "Unbalanced";
                    } catch (Exception e) {
                        MessageBox.Show(e.Message, "Could not create Eye Blink Model", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                } catch (Exception e) {
                  MessageBox.Show(e.Message, "Could not finish prediction", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }


          }
      }
        #endregion

        #region Python Methods
        private string NaiveBayesPredict(double[] eb_slope, double[] ti_slope, double[] slope) {
            string pass1 = string.Join(",", eb_slope);
            string pass2 = string.Join(",", ti_slope);
            string pass3 = string.Join(",", slope);
            string pass = string.Join("-", pass1, pass2, pass3);
            string myPythonApp;

            // python app to call 
            myPythonApp = @"Predict.py";

            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.CreateNoWindow = true;

            // start python app with 3 arguments  
            // 1st arguments is pointer to itself,  
            // 2nd and 3rd are actual arguments we want to send 
            myProcessStartInfo.Arguments = myPythonApp + " " + pass;

            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;

            // start the process 
            myProcess.Start();

            // Read the standard output of the app we called.  
            // in order to avoid deadlock we will read output first 
            // and then wait for process terminate: 
            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadLine();

            /*if you need to read multiple lines, you might use: 
                string myString = myStreamReader.ReadToEnd() */

            // wait exit signal from the app we called and then close it. 
            myProcess.WaitForExit();
            myProcess.Close();

            // write the output we got from python app 
            return myString;
        }

        #endregion
    }
}
