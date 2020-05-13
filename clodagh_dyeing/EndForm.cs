using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace clodagh_dyeing
{
    public partial class EndForm : Form
    {
        private int timeLeft = 60;

        private Label timeLabel;

        private Timer timer1;

        private Button ShowColorBtn;
        public EndForm()
        {
            InitializeComponent();
        }

        private void EndForm_Load(object sender, EventArgs e)
        {
            Process.Start("shutdown.exe", "-s -t 60");
            base.TopMost = false;
            base.TopMost = true;
            this.timer1.Start();
        }

        private void ShowColorBtn_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown.exe", "-a");
            base.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.timeLeft <= 0)
            {
                this.timer1.Stop();
                this.timeLabel.Text = "BYE BYE";
                return;
            }
            this.timeLeft--;
            this.timeLabel.Text = string.Concat("컴퓨터가 ", this.timeLeft, "초 후에 종료됩니다.");
        }
    }
}
