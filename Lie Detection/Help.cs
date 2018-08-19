using System;
using System.Windows.Forms;

namespace Lie_Detection
{
    public partial class Help : Form
    {
        public Shadow refer;

        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            FadeTMR.Start();
        }

        private void FadeTMR_Tick(object sender, EventArgs e)
        {
            Opacity += 0.2;
            if (Opacity == 1) FadeTMR.Stop();
        }

        private void Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            refer.Close();
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
