using System.Windows.Forms;

namespace Lie_Detection
{
    public partial class About : Form
    {
        public Shadow refer;

        public About()
        {
            InitializeComponent();
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            refer.Close();
        }

        private void About_Load(object sender, System.EventArgs e)
        {
            FadeTMR.Start();
        }

        private void FadeTMR_Tick(object sender, System.EventArgs e)
        {
            Opacity += 0.2;
            if (Opacity == 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
