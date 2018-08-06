﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lie_Detection {
    public partial class Report : Form {
        public Main reference = new Main();
        public string data;
        int mode = 0;

        Point lastLocation;
        bool mouseDown;

        public Report() {
            InitializeComponent();
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

        private void EB_MainLBL_MouseEnter(object sender, EventArgs e) {
            EB_MainLBL.ForeColor = Color.FromArgb(112, 112, 112);
        }

        private void EB_MainLBL_MouseLeave(object sender, EventArgs e) {
            if (mode == 0) EB_MainLBL.ForeColor = Color.Silver;
        }

        private void Report_Load(object sender, EventArgs e) {
            LoadData();
            EB_MainPNL.Hide();
            TI_MainPNL.Show();
        }

        private void EB_MainLBL_MouseClick(object sender, MouseEventArgs e) {
            EB_MainPNL.Show();
            TI_MainPNL.Hide();
            EB_MainLBL.ForeColor = Color.FromArgb(112, 112, 112);
            TI_MainLBL.ForeColor = Color.Silver;
            mode = 1;
        }

        private void TI_MainLBL_MouseEnter(object sender, EventArgs e) {
            TI_MainLBL.ForeColor = Color.FromArgb(112, 112, 112);
        }

        private void TI_MainLBL_MouseLeave(object sender, EventArgs e) {
            if (mode == 1) TI_MainLBL.ForeColor = Color.Silver;
        }

        private void TI_MainLBL_MouseClick(object sender, MouseEventArgs e) {
            EB_MainPNL.Hide();
            TI_MainPNL.Show();
            EB_MainLBL.ForeColor = Color.Silver;
            TI_MainLBL.ForeColor = Color.FromArgb(112, 112, 112);
            mode = 0;
        }

        private void LoadData() {
            String a = 
@"=== WATCHING / ASKING ===
22:55.51
22:55.52
22:55.54
22:55.56
22:55.57
22:55.59
22:56.02
22:56.03
22:56.05
22:56.06
22:56.08
22:56.09
22:56.11
22:56.13
22:56.15
=== ANSWERING ===
22:56.21
22:56.21
22:56.22
22:56.23
22:56.23
22:56.26
22:56.27
22:56.28
=== WATCHING / ASKING ===
22:56.31
22:56.33
22:56.36
22:56.38
22:56.40
22:56.41
22:56.42
22:56.44
=== ANSWERING ===
22:56.46
22:56.47
22:56.47
22:56.48
22:56.49
22:56.49
22:56.50
22:56.52
22:56.52
22:56.53
22:56.54
22:56.54
";

            List<double> tempList = new List<double>();
            List<double> normalAverage = new List<double>();
            List<double> afterQuestionAverage = new List<double>();

            List<double> finalAverageList = new List<double>();
            List<double> finalAfterList = new List<double>();

            bool initial = false;
            int flag = 0;
            int temp = 0;
            int blinks = 0;
            using (StringReader reader = new StringReader(a)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    if (line.Equals("=== WATCHING / ASKING ===")) {
                        if (tempList.Count > 0) {
                            finalAfterList.Add(tempList.Sum() / tempList.Count);
                            tempList.Clear();
                        }
                        initial = true;
                        blinks = 0;
                        flag = 1;
                    } else if (line.Equals("=== ANSWERING ===")) {
                        if (tempList.Count > 0) {
                            finalAverageList.Add(tempList.Sum() / tempList.Count);
                            tempList.Clear();
                        }
                        initial = true;
                        blinks = 0;
                        flag = 2;
                    } else {
                        if (initial) { temp = Convert.ToInt32(line.Split('.')[1]); initial = false; }
                        if (Convert.ToInt32(line.Split('.')[1]) < temp + 4) {
                            blinks++;
                        } else {
                            int dataPoint = EB_Q1CHRT.Series["Blinks"].Points.AddXY(line.Split('.')[0] + '.' + (temp + 4).ToString(), blinks);
                            if (flag == 2) {
                                EB_Q1CHRT.Series["Blinks"].Points[dataPoint].Color = Color.FromArgb(151, 128, 128);
                                afterQuestionAverage.Add(blinks);
                                tempList.Add(blinks);
                            } else {
                                normalAverage.Add(blinks);
                                tempList.Add(blinks);
                            }
                            blinks = 0;
                            temp += 4;
                        }
                    }
                } //End of While-loop
            } //End of String Reader

            finalAfterList.Add(tempList.Sum() / tempList.Count);
            tempList.Clear();

            EB_AfterQuestionAveLBL.Text = (afterQuestionAverage.Sum() / afterQuestionAverage.Count).ToString("F2");
            EB_NormalAverageLBL.Text = (normalAverage.Sum() / normalAverage.Count).ToString("F2");

            NaiveBayes nb = new NaiveBayes();
            nb.GenerateModel();

            for (int i = 0; i<finalAfterList.Count; i++) {
                EB_ResultDTGRD.Rows.Add(i+1, finalAverageList[i], finalAfterList[i], finalAfterList[i] / finalAverageList[i],
                        nb.Predict(1.0, finalAfterList[i] / finalAverageList[i]).ToString());
            }

            
        }

        private void Report_SizeChanged(object sender, EventArgs e) {
            EB_ResultDTGRD.Columns[0].Width = Convert.ToInt32(EB_ResultDTGRD.Width * 0.10);
            EB_ResultDTGRD.Columns[1].Width = Convert.ToInt32(EB_ResultDTGRD.Width * 0.25);
            EB_ResultDTGRD.Columns[2].Width = Convert.ToInt32(EB_ResultDTGRD.Width * 0.25);
            EB_ResultDTGRD.Columns[3].Width = Convert.ToInt32(EB_ResultDTGRD.Width * 0.25);
            EB_ResultDTGRD.Columns[4].Width = Convert.ToInt32(EB_ResultDTGRD.Width * 0.15);
        }
    }
}