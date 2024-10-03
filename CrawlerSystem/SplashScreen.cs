using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NM_CongNghePhanMem
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Main mf = new Main();
            mf.ShowDialog();
            this.Hide();
        }
        
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer1 = new Timer();
            timer1.Interval = 3000;
            timer1.Start();
            timer1.Tick += timer1_Tick;
        }
    }
}
