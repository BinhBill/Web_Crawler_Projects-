using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NM_CongNghePhanMem
{
    public partial class Login : Form
    {
        public Login()
        {
            //Thread thread = new Thread(new ThreadStart(StartForm));
            //thread.Start();
            //Thread.Sleep(1500);
            //InitializeComponent();
            //thread.Abort();
        }

        private void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            if(tb_Username.Text=="cnpm" && tb_Password.Text=="demo")
            {
                this.Hide();
                var formMain = new Main();
                formMain.Closed += (s, args) => this.Close();
                formMain.Show();
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
