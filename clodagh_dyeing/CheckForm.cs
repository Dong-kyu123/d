using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace clodagh_dyeing
{
    public partial class CheckForm : Form
    {
        private Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

        private Point m_frmCurrentPosition;

        private Point m_ePostion;

        private bool sizecheck;

        private Label label9;

        private Label label8;

        private Label label7;

        private Label label6;

        private Label label5;

        private Label label4;

        private Label label3;

        private Label label2;

        private Label label1;

        public Panel colorplate;

        public CheckForm()
        {
            this.InitializeComponent();
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = false, SetLastError = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        private void CheckForm_Load(object sender, EventArgs e)
        {
        }

        private void CheckForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.sizecheck)
            {
                base.ClientSize = new Size(164, 27);
                this.sizecheck = true;
                return;
            }
            base.ClientSize = new Size(164, 87);
            this.sizecheck = false;
        }

        private void CheckForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.m_frmCurrentPosition = base.Location;
            this.m_ePostion = new Point(e.X, e.Y);
        }

        private void CheckForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            base.Location = new Point(checked(checked(this.m_frmCurrentPosition.X + e.X) - this.m_ePostion.X), checked(checked(this.m_frmCurrentPosition.Y + e.Y) - this.m_ePostion.Y));
            this.m_frmCurrentPosition = base.Location;
        }

        public void CheckForm_Move(object sender, EventArgs e)
        {
            Point location = base.Location;
            System.Console.WriteLine("BaseLoction : {0}", location);
            int x = checked(location.X + 11);
            Point point = new Point(x, checked(location.Y + 10));
            System.Console.WriteLine("pointer  : {0}", point);
            int num = checked(location.Y + 83);
            Point point1 = new Point(x + 2, checked(location.Y + 24));
            System.Console.WriteLine("pointer 1 : {0}", point1);
            int x1 = checked(location.X + 151);
            Point point2 = new Point(x + 2, checked(location.Y + 38));
            System.Console.WriteLine("pointer 2 : {0}", point2);
            Color colorAt = this.GetColorAt(point);
            System.Console.WriteLine("Color 1 : {0}", colorAt);
            this.label1.Text = Convert.ToString(colorAt.R);
            this.label2.Text = Convert.ToString(colorAt.G);
            this.label3.Text = Convert.ToString(colorAt.B);
            Color color = this.GetColorAt(point1);
            System.Console.WriteLine("Color 2 : {0}", color);
            this.label4.Text = Convert.ToString(color.R);
            this.label5.Text = Convert.ToString(color.G);
            this.label6.Text = Convert.ToString(color.B);
            Color colorAt1 = this.GetColorAt(point2);
            System.Console.WriteLine("Color 3 : {0}", colorAt1);
            this.label7.Text = Convert.ToString(colorAt1.R);
            this.label8.Text = Convert.ToString(colorAt1.G);
            this.label9.Text = Convert.ToString(colorAt1.B);
        }

        public Color GetColorAt(Point location)
        {
            using (Graphics graphic = Graphics.FromImage(this.screenPixel))
            {
                using (Graphics graphic1 = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hdc = graphic1.GetHdc();
                    CheckForm.BitBlt(graphic.GetHdc(), 0, 0, 1, 1, hdc, location.X, location.Y, 13369376);
                    graphic.ReleaseHdc();
                    graphic1.ReleaseHdc();
                }
            }
            return this.screenPixel.GetPixel(0, 0);
        }
    }
}
