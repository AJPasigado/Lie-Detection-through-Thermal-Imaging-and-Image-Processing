using Lie_Detection.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Lie_Detection {
    public partial class AddToModelForm : Form {
        public Report reference = new Report();
        public string python;
        public Shadow refer;
        public string[,] ebti_slope;

        public AddToModelForm() {
            InitializeComponent();
        }

        private void DoneBTN_Click(object sender, EventArgs e) {
            MessageBox.Show("Please wait while we train your model.", "Please Wait", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AppendData();
            string[] accuracy = Model().Split(' ');
            Settings.Default.eb_slope = accuracy[0];
            Settings.Default.ti_slope = accuracy[1];
            Settings.Default.ebti_slope = accuracy[2];
            reference.LoadCombinedData();
            refer.Close();
            Close();
        }

        private void CancelBTN_Click(object sender, EventArgs e) {
            refer.Close();
            Close();
        }

        private void AppendData() {
            string newFileName = @"TrainingSet.csv";

            foreach (DataGridViewRow x in EBTI_SummaryGRD.Rows) {
                if (x.Cells[0].Value != null) {
                    string temp = x.Cells[2].Value.ToString() == "TRUTH" ? "FALSE" : "TRUE";
                    string toPass = x.Cells[0].Value + "," + x.Cells[1].Value + "," + temp + Environment.NewLine;
                    File.AppendAllText(newFileName, toPass);
                }
            }
        }

        private string Model() {
            // python app to call 
            string myPythonApp = @"Model.py";

            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.CreateNoWindow = true;

            // start python app with 3 arguments  
            // 1st arguments is pointer to itself,  
            // 2nd and 3rd are actual arguments we want to send 
            myProcessStartInfo.Arguments = myPythonApp;

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

        private void AddToModelForm_Load(object sender, EventArgs e) {
            for (int i = 0; i < ebti_slope.GetLength(0); i++) {
                EBTI_SummaryGRD.Rows.Add(ebti_slope[i, 1],ebti_slope[i, 0],ebti_slope[i, 2].ToUpper());
            }
        }
    }
}
