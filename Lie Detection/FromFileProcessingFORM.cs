using System;
using System.Windows.Forms;

namespace Lie_Detection
{
    public partial class FromFileProcessingFORM : Form
    {
        public Main reference = new Main();
        public String data;
        public String TI_data;
        public Shadow refer;

        public FromFileProcessingFORM()
        {
            InitializeComponent();
        }

        private void DoneBTN_Click(object sender, EventArgs e)
        {
            reference.EB_PROCESSED_DATA = EB_RealtimeLogTXBX.Text;
            reference.TI_PROCESSED_DATA = TI_RealtimeLogTXBX.Text;
            refer.Close();
            Close();
        }

        private void EB_FromFileProcessingFORM_Load(object sender, EventArgs e)
        {
            EB_RealtimeLogTXBX.Text = data;
            TI_RealtimeLogTXBX.Text = TI_data;
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            refer.Close();
            Close();
        }
    }
}
