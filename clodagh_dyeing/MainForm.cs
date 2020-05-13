using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace clodagh_dyeing
{
    public partial class MainForm : Form
    {
        public bool working;

        public int maxIterations = 3000;

        public int dyecost;

        public bool colourFound;

        private Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

        private CheckForm cF = new CheckForm();

        private EndForm eF = new EndForm();

        private const uint MOUSEMOVE = 0x0001;

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        private const uint ABSOLUTEMOVE = 0x8000;

        private const int HOTKEY_ID = 31197;

        private Point local1;

        private Point local2;

        private Point local3;

        public Color[] colorAt = new Color[3];

        public bool MultiOff = true;

        public int[][] output = new int[0][];

        private decimal waittime = new decimal(5000);

        private bool cfshow;

        private RadioButton radioButton1;

        private RadioButton radioButton2;

        private RadioButton radioButton3;

        private Label label_goal3;

        private TextBox desired1_r2;

        private ToolTip toolTip1;

        private Button MultiBtn;

        private Label label_goal2;

        private TextBox desired1_g2;

        private CheckBox whitechecker;

        private Label label_color3b;

        private Label label1;

        private Label label_goal1;

        private Label label3;

        private TextBox desired1_r;

        private CheckBox graycheck;

        private CheckBox blackcheck;

        private TextBox desired1_g;

        private TextBox desired1_b;

        private TextBox desired1_b2;

        private TextBox desired2_r;

        private TextBox desired2_b;

        private Label label39;

        private TextBox desired2_g;

        private Label label38;

        private Label label_totalgold;

        private TextBox desired2_r2;

        private Label label_color1g;

        private Label label_color1r;

        private Label label_color1b;

        private Label label_color3g;

        private Label label_color2g;

        private Label label_color2b;

        private Label label_color2r;

        private GroupBox groupBox3;

        private Label label40;

        private TextBox desired2_g2;

        private Label label25;

        private TextBox desired2_b2;

        private Label label26;

        private TextBox desired3_r;

        private Label label27;

        private TextBox desired3_g;

        private TextBox desired3_b;

        private TextBox desired3_r2;

        private Label label5;

        private TextBox desired3_g2;

        private Label label4;

        private TextBox desired3_b2;

        private GroupBox groupBox2;

        private Panel colorP1;

        private Button ShowColorBtn;

        private Panel colorP2;

        private Panel colorP3;

        private Label label_color3r;

        private CheckBox offcheck;

        private GroupBox groupBox1;

        private Label label_totalcount;

        private Label dyecount;

        private Label payed;

        private TextBox textBox1;

        private Label clo_dialog;

        private Label label_count;

        private TextBox timeoutBox;

        private BackgroundWorker backgroundWorker1;

        private GroupBox groupBox4;

        private Label label_cost;

        private NumericUpDown waittimectrl;

        private Label label6;

        private Label label2;
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int BitBlt(
          IntPtr hDC,
          int x,
          int y,
          int nWidth,
          int nHeight,
          IntPtr hSrcDC,
          int xSrc,
          int ySrc,
          int dwRop);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, MainForm.KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public MainForm()
        {
            this.cF.Show();
            this.setHotKey(MainForm.KeyModifiers.None, Keys.Home);
            this.InitializeComponent();
        }

        private void animCursorTo(Point newPosition)
        {
            int num = 50;
            Point position = Cursor.Position;
            PointF pointF = position;
            PointF pointF1 = new PointF((float)(checked(newPosition.X - position.X)), (float)(checked(newPosition.Y - position.Y)))
            {
                X = (float)(checked(newPosition.X - position.X)) / (float)num,
                Y = (float)(checked(newPosition.Y - position.Y)) / (float)num
            };
            for (int i = 0; i < num; i = checked(i + 1))
            {
                pointF = new PointF(pointF.X + pointF1.X, pointF.Y + pointF1.Y);
                Cursor.Position = Point.Round(pointF);
                Thread.Sleep(10);
            }
            Cursor.Position = newPosition;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.start();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    {
                        this.clo_dialog.Text = "무슨 색이 나왔을라나";
                        return;
                    }
                case 2:
                    {
                        this.clo_dialog.Text = "색이 맞나...";
                        return;
                    }
                case 3:
                    {
                        this.clo_dialog.Text = "아니네 다시 할께 ";
                        return;
                    }
                case 4:
                    {
                        this.clo_dialog.Text = "염색물이 드는동안 기다려";
                        return;
                    }
                case 5:
                    {
                        this.clo_dialog.Text = "다됬다";
                        return;
                    }
                case 6:
                    {
                        this.clo_dialog.Text = "나왔다!!! 축하해~";
                        this.OffPower();
                        return;
                    }
                case 7:
                    {
                        this.clo_dialog.Text = "벌써 끝이야?";
                        return;
                    }
                case 8:
                    {
                        this.clo_dialog.Text = "아직 안나왔는데 더 안해?";
                        this.OffPower();
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        private void click(){
            
            int x = (int)Cursor.Position.X; 
            int y = (int)Cursor.Position.Y;

            SetCursorPos(x, y);
            MainForm.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(1);
            MainForm.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void desired_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Convert.ToInt32(Keys.Back))
            {
                e.Handled = true;
                return;
            }
            e.Handled = false;
        }

        public Color GetColorAt(Point location)
        {
            using (Graphics graphic = Graphics.FromImage(this.screenPixel))
            {
                using (Graphics graphic1 = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hdc = graphic1.GetHdc();
                    MainForm.BitBlt(graphic.GetHdc(), 0, 0, 1, 1, hdc, location.X, location.Y, 13369376);
                    graphic.ReleaseHdc();
                    graphic1.ReleaseHdc();
                }
            }
            return this.screenPixel.GetPixel(0, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!this.cfshow)
            {
                this.cF.Hide();
                this.cfshow = true;
                return;
            }
            this.cF.Show();
            this.cfshow = false;
        }

        private void MultiBtn_Click(object sender, EventArgs e)
        {
            if (this.MultiOff)
            {
                this.MultiBtn.Text = "단일 파트 확인";
                this.MultiOff = false;
                this.radioButton1.Hide();
                this.radioButton2.Hide();
                this.radioButton3.Hide();
                this.label_goal1.Text = "1파트 목표";
                this.label_goal2.Text = "2파트 목표";
                this.label_goal3.Text = "3파트 목표";
                this.whitechecker.Hide();
                this.blackcheck.Hide();
                this.graycheck.Hide();
                this.desired1_r.Text = "0";
                this.desired1_g.Text = "0";
                this.desired1_b.Text = "0";
                this.desired2_r.Text = "0";
                this.desired2_g.Text = "0";
                this.desired2_b.Text = "0";
                this.desired3_r.Text = "0";
                this.desired3_g.Text = "0";
                this.desired3_b.Text = "0";
                this.desired1_r2.Text = "255";
                this.desired1_g2.Text = "255";
                this.desired1_b2.Text = "255";
                this.desired2_r2.Text = "255";
                this.desired2_g2.Text = "255";
                this.desired2_b2.Text = "255";
                this.desired3_r2.Text = "255";
                this.desired3_g2.Text = "255";
                this.desired3_b2.Text = "255";
                this.BackColor = Color.LightSteelBlue;
                this.clo_dialog.BackColor = Color.LightSteelBlue;
                this.payed.BackColor = Color.SteelBlue;
                this.dyecount.BackColor = Color.SteelBlue;
                this.label6.BackColor = Color.LightSteelBlue;
                this.ShowColorBtn.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
                this.ShowColorBtn.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
                this.MultiBtn.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
                this.MultiBtn.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
                this.toolTip1.SetToolTip(this.MultiBtn, "한개의 파트을 확인하여\n3개의 범위중 하나를 만족하면 염색을 멈춥니다.");
                this.toolTip1.SetToolTip(this.desired1_r, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired2_r, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired3_r, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired1_r2, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired2_r2, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired3_r2, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired1_g, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired2_g, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired3_g, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired1_g2, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired2_g2, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired3_g2, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired1_b, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired2_b, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired3_b, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired1_b2, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired2_b2, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.toolTip1.SetToolTip(this.desired3_b2, "원하는 RGB값의 범위를 입력합니다.\n다중확인모드에선 3개의 범위 모두 만족하여야 염색이 멈추며\n어떤색이 나와도 상관 없으면 RGB 모두 0 | 255로 입력하세요.");
                this.label1.Visible = true;
                return;
            }
            this.MultiBtn.Text = "다중 파트 확인";
            this.MultiOff = true;
            this.radioButton1.Show();
            this.radioButton2.Show();
            this.radioButton3.Show();
            this.label_goal1.Text = "목표 색상";
            this.label_goal2.Text = "목표 색상";
            this.label_goal3.Text = "목표 색상";
            this.whitechecker.Show();
            this.blackcheck.Show();
            this.graycheck.Show();
            this.desired1_r.Text = "0";
            this.desired1_g.Text = "0";
            this.desired1_b.Text = "0";
            this.desired2_r.Text = "0";
            this.desired2_g.Text = "0";
            this.desired2_b.Text = "0";
            this.desired3_r.Text = "0";
            this.desired3_g.Text = "0";
            this.desired3_b.Text = "0";
            this.desired1_r2.Text = "0";
            this.desired1_g2.Text = "0";
            this.desired1_b2.Text = "0";
            this.desired2_r2.Text = "0";
            this.desired2_g2.Text = "0";
            this.desired2_b2.Text = "0";
            this.desired3_r2.Text = "0";
            this.desired3_g2.Text = "0";
            this.desired3_b2.Text = "0";
            this.toolTip1.SetToolTip(this.desired1_r, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired2_r, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired3_r, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired1_r2, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired2_r2, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired3_r2, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired1_g, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired2_g, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired3_g, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired1_g2, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired2_g2, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired3_g2, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired1_b, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired2_b, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired3_b, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired1_b2, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired2_b2, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.toolTip1.SetToolTip(this.desired3_b2, "원하는 RGB값의 범위를 입력합니다.\n단일확인모드에선 3개의 범위 중 하나만 만족하면 염색이 멈추며\n원하는 지정색이 없으면 RGB 모두 0 | 0로 입력하세요.");
            this.BackColor = SystemColors.Control;
            this.clo_dialog.BackColor = SystemColors.Control;
            this.label6.BackColor = SystemColors.Control;
            this.payed.BackColor = SystemColors.ControlLight;
            this.dyecount.BackColor = SystemColors.ControlLight;
            this.ShowColorBtn.FlatAppearance.MouseDownBackColor = SystemColors.ControlLight;
            this.ShowColorBtn.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
            this.MultiBtn.FlatAppearance.MouseDownBackColor = SystemColors.ControlLight;
            this.MultiBtn.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
            this.toolTip1.SetToolTip(this.MultiBtn, "모든 파트를 동시에 체크하여\n모두 지정 범위에 있으면 염색을 멈춥니다.");
            this.label1.Visible = false;
        }

        private void OffPower()
        {
            if (this.offcheck.Checked)
            {
                this.eF.Show();
            }
        }
        public void SetColor()
        {
            this.colorAt[0] = this.GetColorAt(this.local1);
            this.colorAt[1] = this.GetColorAt(this.local2);
            this.colorAt[2] = this.GetColorAt(this.local3);
                
            this.Invoke((MethodInvoker)delegate ()
            {
                this.label_color1r.Text = Convert.ToString(this.colorAt[0].R);
                this.label_color1g.Text = Convert.ToString(this.colorAt[0].G);
                this.label_color1b.Text = Convert.ToString(this.colorAt[0].B);
                this.label_color2r.Text = Convert.ToString(this.colorAt[1].R);
                this.label_color2g.Text = Convert.ToString(this.colorAt[1].G);
                this.label_color2b.Text = Convert.ToString(this.colorAt[1].B);
                this.label_color3r.Text = Convert.ToString(this.colorAt[2].R);
                this.label_color3g.Text = Convert.ToString(this.colorAt[2].G);
                this.label_color3b.Text = Convert.ToString(this.colorAt[2].B);
            });
                
                
            this.colorP1.BackColor = this.colorAt[0];
            this.colorP2.BackColor = this.colorAt[1];
            this.colorP3.BackColor = this.colorAt[2];
        }

        public void SetColorpoint()
        {
            Point location = this.cF.Location;
            int x = checked(location.X + 11);
            int y = checked(location.Y + 10);
            this.local1 = new Point(x, y);
            int y1 = checked(location.Y + 24);
            this.local2 = new Point(x, y1);
            int num1 = checked(location.Y + 38);
            this.local3 = new Point(x, num1);
        }

        public bool setHotKey(MainForm.KeyModifiers Kmds, Keys key)
        {
            return MainForm.RegisterHotKey(this.Handle, 31197, Kmds, key);
        }

        public bool unSetHotKey()
        {
            return MainForm.UnregisterHotKey(this.Handle, 31197);
        }

        private void ShowColorBtn_Click(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate (){
                this.SetColorpoint();
                this.SetColor();
            }));
            
        }

        public void start()
        {
            this.working = true;
            this.colourFound = false;
            int[,] num = new int[3, 3];
            int[,] numArray = new int[3, 3];
            num[0, 0] = Convert.ToInt32(this.desired1_r.Text);
            num[0, 2] = Convert.ToInt32(this.desired1_b.Text);
            num[0, 1] = Convert.ToInt32(this.desired1_g.Text);
            numArray[0, 0] = Convert.ToInt32(this.desired1_r2.Text);
            numArray[0, 2] = Convert.ToInt32(this.desired1_b2.Text);
            numArray[0, 1] = Convert.ToInt32(this.desired1_g2.Text);
            num[1, 0] = Convert.ToInt32(this.desired2_r.Text);
            num[1, 2] = Convert.ToInt32(this.desired2_b.Text);
            num[1, 1] = Convert.ToInt32(this.desired2_g.Text);
            numArray[1, 0] = Convert.ToInt32(this.desired2_r2.Text);
            numArray[1, 2] = Convert.ToInt32(this.desired2_b2.Text);
            numArray[1, 1] = Convert.ToInt32(this.desired2_g2.Text);
            num[2, 0] = Convert.ToInt32(this.desired3_r.Text);
            num[2, 2] = Convert.ToInt32(this.desired3_b.Text);
            num[2, 1] = Convert.ToInt32(this.desired3_g.Text);
            numArray[2, 0] = Convert.ToInt32(this.desired3_r2.Text);
            numArray[2, 2] = Convert.ToInt32(this.desired3_b2.Text);
            numArray[2, 1] = Convert.ToInt32(this.desired3_g2.Text);
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Point position = Cursor.Position;
            Point point = new Point(checked(bounds.Width - 215), 475);
            Point point1 = new Point(checked(bounds.Width - 120), 475);
            this.SetColorpoint();
            this.SetColor();
            int num1 = 0;

            while (!this.colourFound && num1 < this.maxIterations && this.working)
            {
                this.backgroundWorker1.ReportProgress(1);
                this.animCursorTo(position);
                this.click();
                Thread.Sleep(500);
                this.backgroundWorker1.ReportProgress(2);
                this.SetColor();
                bool[,] flagArray = new bool[3, 3];
                int[,] r = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    r[i, 0] = this.colorAt[i].R;
                    r[i, 1] = this.colorAt[i].G;
                    r[i, 2] = this.colorAt[i].B;
                }
                Array.Resize<int[]>(ref this.output, num1 + 1);
                Array.Resize<int>(ref this.output[num1], 9);
                this.output[num1][0] = this.colorAt[0].R;
                this.output[num1][1] = this.colorAt[0].G;
                this.output[num1][2] = this.colorAt[0].B;
                this.output[num1][3] = this.colorAt[1].R;
                this.output[num1][4] = this.colorAt[1].G;
                this.output[num1][5] = this.colorAt[1].B;
                this.output[num1][6] = this.colorAt[2].R;
                this.output[num1][7] = this.colorAt[2].G;
                this.output[num1][8] = this.colorAt[2].B;
                if (!this.MultiOff)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        bool[,] flagArray1 = flagArray;
                        int num2 = j;
                        flagArray1[num2, num2] = (r[j, 0] < num[j, 0] || r[j, 0] > numArray[j, 0] || r[j, 1] < num[j, 1] || r[j, 1] > numArray[j, 1] || r[j, 2] < num[j, 2] ? false : r[j, 2] <= numArray[j, 2]);
                    }
                    if (flagArray[0, 0] && flagArray[1, 1] && flagArray[2, 2])
                    {
                        this.colourFound = true;
                        break;
                    }
                }
                else
                {
                    int num3 = 255;
                    if (this.whitechecker.Checked)
                    {
                        int num4 = 0;
                        while (num4 < 3)
                        {
                            if (this.colorAt[num4].R != num3 || this.colorAt[num4].G != num3 || this.colorAt[num4].B != num3)
                            {
                                num4++;
                            }
                            else
                            {
                                this.colourFound = true;
                                this.SetColor();
                                if (this.colourFound)
                                {
                                    this.backgroundWorker1.ReportProgress(6);
                                    this.animCursorTo(point1);
                                    this.click();
                                    SystemSounds.Beep.Play();
                                }
                                else if (num1 != this.maxIterations)
                                {
                                    this.backgroundWorker1.ReportProgress(7);
                                }
                                else
                                {
                                    this.backgroundWorker1.ReportProgress(8);
                                }
                                this.animCursorTo(position);
                                this.click();
                                this.working = false;
                                return;
                            }
                        }
                    }
                    int num5 = 25;
                    if (this.blackcheck.Checked)
                    {
                        int num6 = 0;
                        while (num6 < 3)
                        {
                            if (this.colorAt[num6].R != num5 || this.colorAt[num6].G != num5 || this.colorAt[num6].B != num5)
                            {
                                num6++;
                            }
                            else
                            {
                                this.colourFound = true;
                                this.SetColor();
                                if (this.colourFound)
                                {
                                    this.backgroundWorker1.ReportProgress(6);
                                    this.animCursorTo(point1);
                                    this.click();
                                    SystemSounds.Beep.Play();
                                }
                                else if (num1 != this.maxIterations)
                                {
                                    this.backgroundWorker1.ReportProgress(7);
                                }
                                else
                                {
                                    this.backgroundWorker1.ReportProgress(8);
                                }
                                this.animCursorTo(position);
                                this.click();
                                this.working = false;
                                return;
                            }
                        }
                    }
                    int num7 = 230;
                    if (this.graycheck.Checked)
                    {
                        int num8 = 0;
                        while (num8 < 3)
                        {
                            if (this.colorAt[num8].R != num7 || this.colorAt[num8].G != num7 || this.colorAt[num8].B != num7)
                            {
                                num8++;
                            }
                            else
                            {
                                this.colourFound = true;
                                this.SetColor();
                                if (this.colourFound)
                                {
                                    this.backgroundWorker1.ReportProgress(6);
                                    this.animCursorTo(point1);
                                    this.click();
                                    SystemSounds.Beep.Play();
                                }
                                else if (num1 != this.maxIterations)
                                {
                                    this.backgroundWorker1.ReportProgress(7);
                                }
                                else
                                {
                                    this.backgroundWorker1.ReportProgress(8);
                                }
                                this.animCursorTo(position);
                                this.click();
                                this.working = false;
                                return;
                            }
                        }
                    }
                    if (this.radioButton1.Checked)
                    {
                        int num9 = 0;
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                flagArray[k, l] = (r[num9, l] < num[k, l] ? false : r[num9, l] <= numArray[k, l]);
                            }
                        }
                        if (flagArray[0, 0] && flagArray[0, 1] && flagArray[0, 2])
                        {
                            this.colourFound = true;
                            break;
                        }
                        else if (flagArray[1, 0] && flagArray[1, 1] && flagArray[1, 2])
                        {
                            this.colourFound = true;
                            break;
                        }
                        else if (flagArray[2, 0] && flagArray[2, 1] && flagArray[2, 2])
                        {
                            this.colourFound = true;
                            break;
                        }
                    }
                    else if (!this.radioButton2.Checked)
                    {
                        int num10 = 2;
                        for (int m = 0; m < 3; m++)
                        {
                            for (int n = 0; n < 3; n++)
                            {
                                flagArray[m, n] = (r[num10, n] < num[m, n] ? false : r[num10, n] <= numArray[m, n]);
                            }
                        }
                        if (flagArray[0, 0] && flagArray[0, 1] && flagArray[0, 2])
                        {
                            this.colourFound = true;
                            break;
                        }
                        else if (flagArray[1, 0] && flagArray[1, 1] && flagArray[1, 2])
                        {
                            this.colourFound = true;
                            break;
                        }
                        else if (flagArray[2, 0] && flagArray[2, 1] && flagArray[2, 2])
                        {
                            this.colourFound = true;
                            break;
                        }
                    }
                    else
                    {
                        int num11 = 1;
                        for (int o = 0; o < 3; o++)
                        {
                            for (int p = 0; p < 3; p++)
                            {
                                flagArray[o, p] = (r[num11, p] < num[o, p] ? false : r[num11, p] <= numArray[o, p]);
                            }
                        }
                        if (flagArray[0, 0] && flagArray[0, 1] && flagArray[0, 2])
                        {
                            this.colourFound = true;
                            break;
                        }
                        else if (flagArray[1, 0] && flagArray[1, 1] && flagArray[1, 2])
                        {
                            this.colourFound = true;
                            break;
                        }
                        else if (flagArray[2, 0] && flagArray[2, 1] && flagArray[2, 2])
                        {
                            this.colourFound = true;
                            break;
                        }
                    }
                }
                this.SetColor();
                this.backgroundWorker1.ReportProgress(3);
                this.animCursorTo(point);
                this.click();
                this.dyecost = Convert.ToInt32(this.textBox1.Text);
                int num12 = (num1 / 3 + 1) * this.dyecost;
                this.payed.Text = Convert.ToString(num12);
                num1 = checked(num1 + 1);
                this.Invoke(new Action(delegate () {
                    this.dyecount.Text = Convert.ToString(num1);
                }));
                this.backgroundWorker1.ReportProgress(4);
                this.waittime = this.waittimectrl.Value * new decimal(1000);
                Thread.Sleep((int)this.waittime);
                this.backgroundWorker1.ReportProgress(5);
            }
            this.SetColor();
            if (this.colourFound)
            {
                this.backgroundWorker1.ReportProgress(6);
                this.animCursorTo(point1);
                this.click();
                SystemSounds.Beep.Play();
            }
            else if (num1 != this.maxIterations)
            {
                this.backgroundWorker1.ReportProgress(7);
            }
            else
            {
                this.backgroundWorker1.ReportProgress(8);
            }
            this.animCursorTo(position);
            this.click();
            this.working = false;
        }

        private void timeoutBox_TextChanged(object sender, EventArgs e)
        {
            this.maxIterations = Convert.ToInt32(this.timeoutBox.Text);
        }


        protected override void WndProc(ref Message message)
        {
            if (message.Msg.Equals(786))
            {
                if (this.working)
                {
                    this.working = false;
                }
                else
                {
                    this.backgroundWorker1.RunWorkerAsync();
                }
            }
            base.WndProc(ref message);
        }

        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }
    }
}
