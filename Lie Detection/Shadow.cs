using System;
using System.Windows.Forms;

namespace Lie_Detection
{
    public partial class Shadow : Form
    {
        public double Transparency;
        public Form Form { get; set; }

        public Shadow()
        {
            InitializeComponent();
        }

        private void FadeTMR_Tick(object sender, EventArgs e)
        {
            Opacity += 0.1;
            if (Opacity >= Transparency)
            {
                FadeTMR.Stop();
                Form.ShowDialog();
            }
        }
        public void Transparent()
        {
            Opacity = 0;
            FadeTMR.Start();
        }
    }
}
