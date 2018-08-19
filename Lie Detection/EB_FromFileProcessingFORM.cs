using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lie_Detection
{
    public partial class EB_FromFileProcessingFORM : Form
    {
        public Main reference = new Main();
        public String data;

        public EB_FromFileProcessingFORM()
        {
            InitializeComponent();
        }

        private void DoneBTN_Click(object sender, EventArgs e)
        {
            reference.EB_ProcessedData = EB_RealtimeLogTXBX.Text;
            Close();
        }

        private void EB_FromFileProcessingFORM_Load(object sender, EventArgs e)
        {
            EB_RealtimeLogTXBX.AppendText("=== WATCHING/ASKING ===\n");
            EB_RealtimeLogTXBX.AppendText(data);
        }
    }
}
